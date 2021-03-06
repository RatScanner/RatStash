﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Force.DeepCloner;
using Newtonsoft.Json.Linq;

namespace RatStash
{
	public class Database
	{
		private Dictionary<string, Item> _items = new Dictionary<string, Item>();
		private Dictionary<string, Type> _nodes = new Dictionary<string, Type>();

		private Database() { }

		/// <summary>
		/// Create a new database object
		/// </summary>
		/// <param name="json">Item data as json string</param>
		/// /// <param name="cleanStrings">Replace cyrillic characters with similar looking latin characters</param>
		public static Database FromString(string json, bool cleanStrings = true)
		{
			if (cleanStrings) json = CleanString(json);

			var db = new Database();
			db.Load(json);
			return db;
		}

		/// <summary>
		/// Create a new database object
		/// </summary>
		/// <param name="filepath">Path to the file, containing the item data</param>
		/// <param name="cleanStrings">Replace cyrillic characters with similar looking latin characters</param>
		public static Database FromFile(string filepath, bool cleanStrings = true)
		{
			string json;
			{
				using var fileStream = File.Open(filepath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
				using var textReader = new StreamReader(fileStream);
				json = textReader.ReadToEnd();
			}
			return FromString(json, cleanStrings);
		}

		/// <summary>
		/// Replace cyrillic characters with similar looking latin characters
		/// </summary>
		/// <param name="input">The string which contains cyrillic characters</param>
		/// <returns>The input string with replace characters</returns>
		private static string CleanString(string input)
		{
			const string cyrillicChars = "АВЕЅZІКМНОРСТХШѴУ";
			const string latinChars = "ABESZIKMHOPCTXWVY";

			for (var i = 0; i < cyrillicChars.Length; i++)
			{
				input = input.Replace(cyrillicChars[i], latinChars[i]);
			}

			return input;
		}

		/// <summary>
		/// Load the item data from a file
		/// </summary>
		/// <param name="json">Item data as json string</param>
		private void Load(string json)
		{
			var jObj = JObject.Parse(json);
			var items = jObj.Children();

			// First pass to determine node hierarchy
			foreach (var item in items)
			{
				var itemInfo = item.First;
				if ((string)itemInfo["_type"] == "Node")
				{
					_nodes.Add((string)itemInfo["_id"], NameToItemType((string)itemInfo["_name"]));
				}
			}

			// Second pass to parse actual items
			foreach (var item in items)
			{
				var itemInfo = item.First;
				if ((string)itemInfo["_type"] != "Item") continue;

				var parent = ResolveParentType((string)itemInfo["_parent"]);
				var id = (string)itemInfo["_id"];
				try
				{
					var parsedItem = (Item)itemInfo["_props"].ToObject(parent);
					if (parsedItem == null) continue;
					parsedItem.Id = id;
					_items.Add(id, parsedItem);
				}
				catch
				{
					// ignored
#if DEBUG
					throw;
#endif
				}
			}
		}

		private Type NameToItemType(string name)
		{
			return name switch
			{
				"Item" => typeof(Item),
				"Fuel" => typeof(Fuel),
				"HouseholdGoods" => typeof(HouseholdGoods),
				"Jewelry" => typeof(Jewelry),
				"Battery" => typeof(Battery),
				"Electronics" => typeof(Electronics),
				"Tool" => typeof(Tool),
				"MedicalSupplies" => typeof(MedicalSupplies),
				"Lubricant" => typeof(Lubricant),
				"BuildingMaterial" => typeof(BuildingMaterial),
				"Other" => typeof(Other),
				"FlashHider" => typeof(Flashhider),
				"Silencer" => typeof(Silencer),
				"Pms" => typeof(Pms),
				"Compensator" => typeof(Compensator),
				"MuzzleCombo" => typeof(CombMuzzleDevice),
				"NightVision" => typeof(NightVision),
				"ThermalVision" => typeof(ThermalVision),
				"SpecialScope" => typeof(SpecialScope),
				"CompactCollimator" => typeof(CompactCollimator),
				"IronSight" => typeof(IronSight),
				"AssaultScope" => typeof(AssaultScope),
				"Collimator" => typeof(Collimator),
				"OpticScope" => typeof(OpticScope),
				"Bipod" => typeof(Bipod),
				"LightLaser" => typeof(LaserDesignator),
				"TacticalCombo" => typeof(CombTactDevice),
				"Flashlight" => typeof(Flashlight),
				"Foregrip" => typeof(Foregrip),
				"RailCovers" => typeof(RailCovers),
				"Gasblock" => typeof(GasBlock),
				"AuxiliaryMod" => typeof(AuxiliaryMod),
				"Muzzle" => typeof(MuzzleDevice),
				"Sights" => typeof(Sights),
				"Stock" => typeof(Stock),
				"Charge" => typeof(ChargingHandle),
				"Mount" => typeof(Mount),
				"Launcher" => typeof(Launcher),
				"Shaft" => typeof(MagShaft),
				"Magazine" => typeof(Magazine),
				"Handguard" => typeof(Handguard),
				"PistolGrip" => typeof(PistolGrip),
				"Barrel" => typeof(Barrel),
				"Receiver" => typeof(Receiver),
				"MasterMod" => typeof(EssentialMod),
				"GearMod" => typeof(GearMod),
				"FunctionalMod" => typeof(FunctionalMod),
				"Pockets" => typeof(Pockets),
				"LootContainer" => typeof(LootContainer),
				"Vest" => typeof(ChestRig),
				"Backpack" => typeof(Backpack),
				"MobContainer" => typeof(PortableContainer),
				"AssaultCarbine" => typeof(AssaultCarbine),
				"MarksmanRifle" => typeof(MarksmanRifle),
				"Shotgun" => typeof(Shotgun),
				"GrenadeLauncher" => typeof(GrenadeLauncher),
				"SniperRifle" => typeof(SniperRifle),
				"Pistol" => typeof(Handgun),
				"AssaultRifle" => typeof(AssaultRifle),
				"Smg" => typeof(Smg),
				"SpecialWeapon" => typeof(SpecialWeapon),
				"MachineGun" => typeof(Machinegun),
				"Armor" => typeof(Armor),
				"Visors" => typeof(VisObservDevice),
				"FaceCover" => typeof(FaceCover),
				"Headwear" => typeof(Headwear),
				"ArmBand" => typeof(ArmBand),
				"Headphones" => typeof(Headphones),
				"ArmoredEquipment" => typeof(ArmoredEquipment),
				"SearchableItem" => typeof(SearchableItem),
				"SimpleContainer" => typeof(CommonContainer),
				"Mod" => typeof(WeaponMod),
				"LockableContainer" => typeof(LockingContainer),
				"StationaryContainer" => typeof(StationaryContainer),
				"Inventory" => typeof(Inventory),
				"Stash" => typeof(Stash),
				"Equipment" => typeof(Equipment),
				"Weapon" => typeof(Weapon),
				"Drink" => typeof(Drink),
				"Food" => typeof(Food),
				"KeyMechanical" => typeof(KeyMechanical),
				"Keycard" => typeof(Keycard),
				"Stimulator" => typeof(Stimulator),
				"Medical" => typeof(MedicalItem),
				"MedKit" => typeof(Medikit),
				"Drugs" => typeof(Drug),
				"Compass" => typeof(Compass),
				"Money" => typeof(Money),
				"AmmoBox" => typeof(AmmoContainer),
				"Ammo" => typeof(Ammo),
				"StackableItem" => typeof(StackableItem),
				"SpecItem" => typeof(SpecialItem),
				"CompoundItem" => typeof(CompoundItem),
				"Map" => typeof(Map),
				"BarterItem" => typeof(BarterItem),
				"Info" => typeof(Info),
				"Key" => typeof(Key),
				"FoodDrink" => typeof(FoodAndDrink),
				"Meds" => typeof(Meds),
				"ThrowWeap" => typeof(ThrowableWeapon),
				"Knife" => typeof(Knife),
				_ => typeof(Item)
			};
		}

		internal Type ResolveParentType(string id)
		{
			return _nodes[id];
		}

		/// <summary>
		/// Get all items
		/// </summary>
		/// <returns>A enumerable containing all items in the database</returns>
		public IEnumerable<Item> GetItems()
		{
			return _items.Values.AsEnumerable().DeepClone();
		}

		/// <summary>
		/// Get a item by its id
		/// </summary>
		/// <param name="id">The 24 character id of the item</param>
		/// <returns>Item from the database</returns>
		/// <remarks>Runtime of O(1)</remarks>
		public Item GetItem(string id)
		{
			_items.TryGetValue(id, out var value);
			return value.DeepClone();
		}

		/// <summary>
		/// Get a item with the highest rating determined by the rating function
		/// </summary>
		/// <param name="ratingFunction">Function to rate a item</param>
		/// <returns>The item with the highest rating</returns>
		/// <remarks>Particularly useful in combination with editor distance algorithms to get items by name / short name</remarks>
		public Item GetItem(Func<Item, int> ratingFunction)
		{
			var rf = ratingFunction;
			return _items.Values.Aggregate((agg, next) => rf(next) > rf(agg) ? next : agg).DeepClone();
		}

		/// <summary>
		/// Get items by discriminator function
		/// </summary>
		/// <param name="filter">Function to determine what items should be returned</param>
		/// <returns>A enumerable containing all items, passing the filter</returns>
		public IEnumerable<Item> GetItems(Func<Item, bool> filter)
		{
			return _items.Values.Where(filter).DeepClone();
		}

		/// <summary>
		/// Check if a id is associated to a node
		/// </summary>
		/// <param name="id">The id to check</param>
		/// <returns><see langword="true"/> if the id is associated with a node</returns>
		/// <remarks>Runtime of O(n)</remarks>
		public bool IsNode(string id)
		{
			return _nodes.ContainsKey(id);
		}

		/// <summary>
		/// Create a new <see cref="Database"/> instance, containing all items, passing the filter
		/// </summary>
		/// <param name="filter">Function to determine what items should be included</param>
		/// <returns>A new <see cref="Database"/> instance</returns>
		public Database Filter(Func<Item, bool> filter)
		{
			var db = new Database
			{
				_items = _items.Where(map => filter(map.Value)).ToDictionary(x => x.Key, x => x.Value).DeepClone(),
				_nodes = _nodes.DeepClone()
			};
			return db;
		}

		/// <summary>
		/// Parse a item cache index file into a dictionary of <see cref="Item"/> and <see cref="ItemExtraInfo"/>
		/// </summary>
		/// <param name="filepath">The path to the cache index file</param>
		/// <returns>The parsed cache index</returns>
		public Dictionary<int, (Item item, ItemExtraInfo itemExtraInfo)> ParseItemCacheIndex(string filepath)
		{
			var parser = new CacheIndexParser(this);
			return parser.Parse(filepath);
		}
	}
}
