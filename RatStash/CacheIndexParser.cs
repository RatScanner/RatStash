using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace RatStash
{
	internal class CacheIndexParser
	{
		private readonly Database _database;

		internal CacheIndexParser(Database database)
		{
			_database = database;
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
				items.Add(index, DeserializeItem(correlation.Name));
			}

			return items;
		}

		private (Item, ItemExtraInfo) DeserializeItem(string serializedItem)
		{
			// item ::= id ' ' subContainer* ( ammoItem | toggableComponent | foldableComponent | magazineItem )?

			// Parse top level item id
			string id;
			(id, serializedItem) = serializedItem.Split(" ");
			var item = _database.GetItem(id);
			if (item == null) return (null, null);

			// Find extra info of top level item
			string serializedExtraInfo;
			var containsSubContainers = serializedItem.Contains(", ");
			if (containsSubContainers)
			{
				(serializedItem, serializedExtraInfo) = serializedItem.Split(", ", true);
				serializedItem += ", ";
			}
			else
			{
				serializedExtraInfo = serializedItem;
				serializedItem = "";
			}

			// Parse extra info of top level item
			var extraInfo = new ItemExtraInfo();
			if (item is Ammo)
			{
				var (_, right) = serializedExtraInfo.Split(": ");
				extraInfo.AmmoIsUsed = bool.Parse(right);
			}

			extraInfo += DeserializeItemExtraInfo(item, serializedExtraInfo);

			// Parse sub containers
			var subContainers = serializedItem.Split(new[] { ", " }, StringSplitOptions.None);
			var tmp = (item, extraInfo);
			foreach (var subContainer in subContainers)
			{
				if (subContainer.Trim() == "") continue;
				tmp = DeserializeSubContainer(tmp.item, tmp.extraInfo, subContainer);
			}

			return tmp;
		}

		private (Item, ItemExtraInfo) DeserializeSubContainer(Item item, ItemExtraInfo extraInfo, string subContainer)
		{
			// subContainer ::= name ':' ' ' _serializedItem*
			var (name, serializedItems) = subContainer.Split(": ");

			// TODO Add 'Chamber' and 'StackSlots' parsing
			if (name == "patron_in_weapon" || name == "cartridges") return (item, extraInfo);

			// Return if item is not a compound item or the serialized item is empty
			if (!(item is CompoundItem) || serializedItems == "") return (item, extraInfo);

			// Since we know, that the item is a compound item, the
			// sub container can only contain a maximum of one item.

			// Remove trailing space of serialized item
			serializedItems = serializedItems.Remove(serializedItems.Length - 1);

			// We can abort here if the sub item is null
			if (serializedItems.StartsWith("null ")) return (item, extraInfo);

			var id = serializedItems.Substring(0, 24);
			var subItem = _database.GetItem(id);
			serializedItems = serializedItems.Remove(0, 24);
			if (serializedItems != "")
			{
				extraInfo += DeserializeItemExtraInfo(subItem, serializedItems);
			}

			if (serializedItems != "" && serializedItems.Split(":", true).left != "")
			{
				throw new ArgumentException("Unable to parse sub item.");
			}

			var success = InsertInSlotByName(item, subItem, name);
			if (!success) throw new ArgumentException($"Unable to insert {subItem.Id} into {name} on {item}.");

			return (item, extraInfo);
		}

		private bool InsertInSlotByName(Item target, Item item, string slotName)
		{
			if (!(target is CompoundItem typedTarget))
			{
				return false;
			}

			foreach (var slot in typedTarget.Slots)
			{
				if (slot.ContainedItem != null)
				{
					if (InsertInSlotByName(slot.ContainedItem, item, slotName)) return true;
					continue;
				}

				if (slot.Name != slotName) continue;
				slot.ContainedItem = item;
				slot.ParentItem = typedTarget;
				return true;
			}

			return false;
		}

		private ItemExtraInfo DeserializeItemExtraInfo(Item item, string serializedExtraInfo)
		{
			// itemExtraInfo :: = togglableComponent | foldableComponent | magazineItem
			var extraInfo = new ItemExtraInfo();
			switch (item)
			{
				case ArmoredEquipment armoredEquipment:
					if (armoredEquipment.HasHinge)
					{
						var (_, right) = serializedExtraInfo.Split(":");
						extraInfo.ItemIsToggled = bool.Parse(right);
					}

					break;
				case NightVision nightVision:
					if (nightVision.HasHinge)
					{
						var (_, right) = serializedExtraInfo.Split(":");
						extraInfo.ItemIsToggled = bool.Parse(right);
					}

					break;
				case Weapon weapon:
					{
						if (weapon.Foldable)
						{
							var (_, right) = serializedExtraInfo.Split(":");
							extraInfo.WeaponIsFolded = bool.Parse(right);
						}

						break;
					}
				case Magazine _:
					{
						var (_, right) = serializedExtraInfo.Split(":");
						extraInfo.MaxVisibleAmmo = int.Parse(right);
						break;
					}
			}

			return extraInfo;
		}
	}
}
