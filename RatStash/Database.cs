using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace RatStash
{
	public class Database
	{
		private static Dictionary<string, Item> _items = new Dictionary<string, Item>();
		private static Dictionary<string, Type> _nodes = new Dictionary<string, Type>();

		/// <summary>
		/// Load the item data from a file
		/// </summary>
		/// <param name="filepath">Path to the json file</param>
		public static void Load(string filepath)
		{
			var json = File.ReadAllText(filepath);
			var jObj = JObject.Parse(json);
			var items = jObj.Children();

			// First pass to determine node hierarchy
			foreach (var item in items)
			{
				var itemInfo = item.First;
				if ((string)itemInfo["_type"] == "Node")
				{
					_nodes.Add((string)itemInfo["_id"], NameToItemType((string)itemInfo["_props"]["Name"]));
				}
			}

			// Second pass to parse actual items
			foreach (var item in items)
			{
				var itemInfo = item.First;
				if ((string)itemInfo["_type"] == "Item")
				{
					var parent = ResolveParentType((string)itemInfo["_parent"]);
					_items.Add((string)itemInfo["_id"], (Item)itemInfo["_props"].ToObject(parent));
				}
			}
		}

		private static Type NameToItemType(string name)
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

		private static Type ResolveParentType(string id)
		{
			return _nodes[id];
		}

		public static Item FindById(string id)
		{
			_items.TryGetValue(id, out var value);
			return value;
		}

		public static bool IsNode(string id)
		{
			return _nodes.ContainsKey(id);
		}
	}
}
