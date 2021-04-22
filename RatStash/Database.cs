using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Force.DeepCloner;
using Newtonsoft.Json.Linq;

namespace RatStash
{
	public class Database
	{
		private readonly Dictionary<string, Item> _items = new Dictionary<string, Item>();
		private readonly Dictionary<string, Type> _nodes = new Dictionary<string, Type>();

		private Database() { }

		/// <summary>
		/// Create a new database object
		/// </summary>
		/// <param name="json">Item data as json string</param>
		public static Database FromString(string json)
		{
			var db = new Database();
			db.Load(json);
			return db;
		}

		/// <summary>
		/// Create a new database object
		/// </summary>
		/// <param name="filepath">Path to the file, containing the item data</param>
		public static Database FromFile(string filepath)
		{
			string json;
			{
				using var fileStream = File.Open(filepath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
				using var textReader = new StreamReader(fileStream);
				json = textReader.ReadToEnd();
			}
			return FromString(json);
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
				if ((string)itemInfo["_type"] == "Item")
				{
					var parent = ResolveParentType((string)itemInfo["_parent"]);
					var id = (string)itemInfo["_id"];
					var parsedItem = (Item)itemInfo["_props"].ToObject(parent);
					if (parsedItem != null)
					{
						parsedItem.Id = id;
						_items.Add(id, parsedItem);
					}
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
		/// Get all items
		/// </summary>
		/// <returns>A enumerable containing all items in the database</returns>
		public IEnumerable<Item> GetItems()
		{
			return _items.Values.AsEnumerable().DeepClone();
		}

		/// <summary>
		/// Get items by discriminator function
		/// </summary>
		/// <param name="discriminator">Function which takes <see cref="Item"/> and</param>
		/// <returns></returns>
		public IEnumerable<Item> GetItems(Func<Item, bool> discriminator)
		{
			return _items.Values.Where(discriminator).DeepClone();
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
