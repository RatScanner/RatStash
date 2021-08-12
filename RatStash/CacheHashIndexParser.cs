using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace RatStash
{
	internal class CacheHashIndexParser
	{
		private readonly Database _database;

		private readonly Dictionary<int, (Item, ItemExtraInfo)> _hashLookup = new();

		internal CacheHashIndexParser(Database database)
		{
			_database = database;
			LoadHashLookupTable();
		}

		internal Dictionary<int, (Item, ItemExtraInfo)> Parse(string filepath)
		{
			string json;
			{
				using var fileStream = File.Open(filepath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
				using var textReader = new StreamReader(fileStream);
				json = textReader.ReadToEnd();
			}

			var correlations = JObject.Parse(json);

			var items = new Dictionary<int, (Item, ItemExtraInfo)>();

			foreach (var correlation in correlations.Properties())
			{
				var index = (int)correlation.Value;
				if (!int.TryParse(correlation.Name, out var hash)) continue;
				// Ignore stuff like folding: hash &= ~0x3FF;
				if (!_hashLookup.TryGetValue(hash, out var match)) continue;
				items.Add(index, match);
			}

			return items;
		}

		private void LoadHashLookupTable()
		{
			foreach (var item in _database.GetItems())
			{
				var hash = GetItemHash(item, new ItemExtraInfo());
				// Ignore stuff like folding: hash &= ~0x3FF;
				if (_hashLookup.ContainsKey(hash)) throw new Exception("Key collision!");
				_hashLookup[hash] = (item, new ItemExtraInfo());
			}
		}

		private int GetItemHash(Item item, ItemExtraInfo itemExtraInfo)
		{
			var hash = 17;
			hash ^= GetSingleItemHash(item, itemExtraInfo);

			if (item is CompoundItem { HideEntrails: false } compoundItem)
			{
				hash = GetContainerHash(hash, compoundItem.Slots);
			}

			if (item is Magazine magazine)
			{
				hash = GetContainerHash(hash, magazine.Cartridges);
			}

			if (item is AmmoContainer ammoContainer)
			{
				hash = GetContainerHash(hash, ammoContainer.StackSlots);
			}

			if (item is Ammo)
			{
				// Ammo is never used when rendered in the inventory
				// hash ^= 27 * (ammo.IsUsed ? 42 : 56);
				hash ^= 27 * 56;
			}

			return hash;
		}

		private int GetContainerHash(int hash, IEnumerable<IContainer> containers)
		{

			foreach (var container in containers)
			{
				hash ^= GetStringHash(container.Name);
				foreach (var item in container.Items)
				{
					hash ^= GetSingleItemHash(item, new ItemExtraInfo());
				}
			}

			return hash;
		}

		private int GetSingleItemHash(Item item, ItemExtraInfo itemExtraInfo)
		{
			var hash = 0;
			if (item == null) return hash;
			hash ^= GetStringHash(item.Id);

			switch (item)
			{
				case NightVision:
				case ThermalVision:
				case ArmoredEquipment:
					if (item is ArmoredEquipment { HasHinge: false }) break;
					hash ^= 23 + (itemExtraInfo.ItemIsToggled ? 1 : 0);
					break;
				case Weapon:
					hash ^= 23 + (itemExtraInfo.WeaponIsFolded ? 1 : 0) << 1;
					break;
				case Magazine magazine:
					hash ^= 23 + magazine.GetMaxVisibleAmmo() << 2;
					break;
			}

			return hash;
		}

		private int GetStringHash(string value)
		{
			unsafe
			{
				fixed (char* src = value)
				{
					var hash1 = 5381;
					var hash2 = hash1;

					int c;
					var s = src;
					while ((c = s[0]) != 0)
					{
						hash1 = ((hash1 << 5) + hash1) ^ c;
						c = s[1];
						if (c == 0)
							break;
						hash2 = ((hash2 << 5) + hash2) ^ c;
						s += 2;
					}

					return hash1 + (hash2 * 1566083941);
				}
			}
		}
	}
}
