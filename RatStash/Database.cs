using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Force.DeepCloner;
using Newtonsoft.Json.Linq;

namespace RatStash;

public class Database
{
	private Dictionary<string, Item> _items = new();
	private Dictionary<string, Type> _nodes = new();

	private CacheIndexParser _indexParser;
	private CacheHashIndexParser _hashIndexParser;

	private CacheIndexParser CacheIndexParserInstance => _indexParser ??= new CacheIndexParser(this);
	private CacheHashIndexParser CacheHashIndexParserInstance => _hashIndexParser ??= new CacheHashIndexParser(this);

	private Database() { }

	/// <summary>
	/// Create a new database object
	/// </summary>
	/// <param name="items">Item data as json string</param>
	/// <param name="cleanStrings">Replace cyrillic characters with similar looking latin characters</param>
	/// <param name="locale">Localization data as json string</param>
	public static Database FromString(string items, bool cleanStrings, string locale = null)
	{
		if (cleanStrings) items = items.CyrillicToLatin();

		var db = new Database();

		db.Load(JObject.Parse(items));
		if (locale != null) db.LoadLocale(JObject.Parse(locale));

		if (cleanStrings) db.CleanStrings();
		return db;
	}

	/// <summary>
	/// Create a new database object
	/// </summary>
	/// <param name="itemPath">Path to the file, containing the item data</param>
	/// <param name="localePath">Path to the file, containing the localization data</param>
	public static Database FromFile(string itemPath, bool cleanStrings, string localePath = null)
	{
		var serializer = new JsonSerializer();

		using var itemFileStream = File.Open(itemPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
		using var itemTextReader = new StreamReader(itemFileStream);
		using var itemJsonReader = new JsonTextReader(itemTextReader);

		var itemJObject = serializer.Deserialize<JObject>(itemJsonReader);

		var db = new Database();
		db.Load(itemJObject);

		if (localePath != null)
		{
			using var localeFileStream = File.Open(localePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			using var localeTextReader = new StreamReader(localeFileStream);
			using var localeJsonReader = new JsonTextReader(localeTextReader);

			var localeJObject = serializer.Deserialize<JObject>(localeJsonReader);
			db.LoadLocale(localeJObject);
		}

		if (cleanStrings) db.CleanStrings();
		return db;
	}

	/// <summary>
	/// Load the item data from a file
	/// </summary>
	/// <param name="itemData">Item data as <see cref="JObject"/></param>
	private void Load(JObject itemData)
	{
		var settings = new JsonSerializerSettings
		{
#if DEBUG
			MissingMemberHandling = MissingMemberHandling.Error,
#endif
		};

		var serializer = JsonSerializer.Create(settings);
		var items = itemData.Children();

		// First pass to determine node hierarchy
		Parallel.ForEach(items, item =>
		{
			var itemInfo = item.First;
			if ((string)itemInfo["_type"] == "Node")
			{
				lock (_nodes)
				{
					_nodes.Add((string)itemInfo["_id"], NameToItemType((string)itemInfo["_name"]));
				}
			}
		});

		// Second pass to parse actual items
		Parallel.ForEach(items, item =>
		{
			var itemInfo = item.First;
			if ((string)itemInfo["_type"] != "Item") return;

			var parent = ResolveParentType((string)itemInfo["_parent"]);
			var id = (string)itemInfo["_id"];
			try
			{
				var parsedItem = (Item)itemInfo["_props"].ToObject(parent, serializer);
				if (parsedItem == null) return;
				parsedItem.Id = id;
				lock (_items)
				{
					_items.Add(id, parsedItem);
				}
			}
			catch
			{
				// ignored
#if DEBUG
				throw;
#endif
			}
		});
	}

	/// <summary>
	/// Load the locale data from a file and insert it into the current loaded database
	/// </summary>
	/// <param name="translations">Locale data as <see cref="JObject"/></param>
	private void LoadLocale(JObject translations)
	{
		foreach (var itemId in _items.Keys)
		{
			var name = translations[itemId + " Name"];
			if (name != null && _items[itemId].Name != null) _items[itemId].Name = name.Value<string>();

			var shortName = translations[itemId + " ShortName"];
			if (shortName != null && _items[itemId].ShortName != null) _items[itemId].ShortName = shortName.Value<string>();

			var description = translations[itemId + " Description"];
			if (description != null && _items[itemId].Description != null) _items[itemId].Description = description.Value<string>();
		}
	}

	private Type NameToItemType(string name)
	{
		return name switch
		{
			nameof(Item) => typeof(Item),
			nameof(Fuel) => typeof(Fuel),
			nameof(HouseholdGoods) => typeof(HouseholdGoods),
			nameof(Jewelry) => typeof(Jewelry),
			nameof(Battery) => typeof(Battery),
			nameof(Electronics) => typeof(Electronics),
			nameof(Tool) => typeof(Tool),
			nameof(MedicalSupplies) => typeof(MedicalSupplies),
			nameof(Lubricant) => typeof(Lubricant),
			nameof(BuildingMaterial) => typeof(BuildingMaterial),
			nameof(Other) => typeof(Other),
			"FlashHider" => typeof(Flashhider),
			nameof(Silencer) => typeof(Silencer),
			nameof(Pms) => typeof(Pms),
			nameof(Compensator) => typeof(Compensator),
			"MuzzleCombo" => typeof(CombMuzzleDevice),
			nameof(NightVision) => typeof(NightVision),
			nameof(ThermalVision) => typeof(ThermalVision),
			nameof(SpecialScope) => typeof(SpecialScope),
			nameof(CompactCollimator) => typeof(CompactCollimator),
			nameof(IronSight) => typeof(IronSight),
			nameof(AssaultScope) => typeof(AssaultScope),
			nameof(Collimator) => typeof(Collimator),
			nameof(OpticScope) => typeof(OpticScope),
			nameof(Bipod) => typeof(Bipod),
			"LightLaser" => typeof(LaserDesignator),
			"TacticalCombo" => typeof(CombTactDevice),
			nameof(Flashlight) => typeof(Flashlight),
			nameof(Foregrip) => typeof(Foregrip),
			nameof(RailCovers) => typeof(RailCovers),
			"Gasblock" => typeof(GasBlock),
			nameof(AuxiliaryMod) => typeof(AuxiliaryMod),
			"Muzzle" => typeof(MuzzleDevice),
			nameof(Sights) => typeof(Sights),
			nameof(Stock) => typeof(Stock),
			"Charge" => typeof(ChargingHandle),
			nameof(Mount) => typeof(Mount),
			nameof(Launcher) => typeof(Launcher),
			"Shaft" => typeof(MagShaft),
			nameof(Magazine) => typeof(Magazine),
			nameof(CylinderMagazine) => typeof(CylinderMagazine),
			nameof(SpringDrivenCylinder) => typeof(SpringDrivenCylinder),
			nameof(Handguard) => typeof(Handguard),
			nameof(PistolGrip) => typeof(PistolGrip),
			nameof(Barrel) => typeof(Barrel),
			nameof(Receiver) => typeof(Receiver),
			"MasterMod" => typeof(EssentialMod),
			nameof(GearMod) => typeof(GearMod),
			nameof(FunctionalMod) => typeof(FunctionalMod),
			nameof(Pockets) => typeof(Pockets),
			nameof(LootContainer) => typeof(LootContainer),
			"Vest" => typeof(ChestRig),
			nameof(Backpack) => typeof(Backpack),
			"MobContainer" => typeof(PortableContainer),
			nameof(AssaultCarbine) => typeof(AssaultCarbine),
			nameof(MarksmanRifle) => typeof(MarksmanRifle),
			nameof(Shotgun) => typeof(Shotgun),
			nameof(GrenadeLauncher) => typeof(GrenadeLauncher),
			nameof(SniperRifle) => typeof(SniperRifle),
			"Pistol" => typeof(Handgun),
			nameof(AssaultRifle) => typeof(AssaultRifle),
			nameof(Smg) => typeof(Smg),
			nameof(SpecialWeapon) => typeof(SpecialWeapon),
			"MachineGun" => typeof(Machinegun),
			nameof(Revolver) => typeof(Revolver),
			nameof(Armor) => typeof(Armor),
			"Visors" => typeof(VisObservDevice),
			nameof(FaceCover) => typeof(FaceCover),
			nameof(Headwear) => typeof(Headwear),
			nameof(ArmBand) => typeof(ArmBand),
			nameof(Headphones) => typeof(Headphones),
			nameof(ArmoredEquipment) => typeof(ArmoredEquipment),
			nameof(SearchableItem) => typeof(SearchableItem),
			"SimpleContainer" => typeof(CommonContainer),
			"Mod" => typeof(WeaponMod),
			"LockableContainer" => typeof(LockingContainer),
			nameof(StationaryContainer) => typeof(StationaryContainer),
			nameof(RandomLootContainer) => typeof(RandomLootContainer),
			nameof(Inventory) => typeof(Inventory),
			nameof(Stash) => typeof(Stash),
			nameof(SortingTable) => typeof(SortingTable),
			nameof(Equipment) => typeof(Equipment),
			nameof(Weapon) => typeof(Weapon),
			nameof(Drink) => typeof(Drink),
			nameof(Food) => typeof(Food),
			nameof(KeyMechanical) => typeof(KeyMechanical),
			nameof(Keycard) => typeof(Keycard),
			nameof(Stimulator) => typeof(Stimulator),
			"Medical" => typeof(MedicalItem),
			"MedKit" => typeof(Medikit),
			"Drugs" => typeof(Drug),
			nameof(Compass) => typeof(Compass),
			nameof(RadioTransmitter) => typeof(RadioTransmitter),
			nameof(PortableRangeFinder) => typeof(PortableRangeFinder),
			"RepairKits" => typeof(RepairKit),
			nameof(Money) => typeof(Money),
			"AmmoBox" => typeof(AmmoContainer),
			nameof(Ammo) => typeof(Ammo),
			nameof(StackableItem) => typeof(StackableItem),
			"SpecItem" => typeof(SpecialItem),
			nameof(CompoundItem) => typeof(CompoundItem),
			nameof(Map) => typeof(Map),
			nameof(BarterItem) => typeof(BarterItem),
			nameof(Info) => typeof(Info),
			nameof(Key) => typeof(Key),
			"FoodDrink" => typeof(FoodAndDrink),
			nameof(Meds) => typeof(Meds),
			"ThrowWeap" => typeof(ThrowableWeapon),
			nameof(Knife) => typeof(Knife),
#if !DEBUG
			_ => typeof(Item),
#else
			_ => throw new ArgumentOutOfRangeException(nameof(name), name, null),
#endif
		};
	}

	internal Type ResolveParentType(string id)
	{
		return _nodes[id];
	}

	public void CleanStrings()
	{
		foreach (var itemId in _items.Keys)
		{
			if (_items[itemId].Name != null) _items[itemId].Name = _items[itemId].Name.CyrillicToLatin();
			if (_items[itemId].ShortName != null) _items[itemId].ShortName = _items[itemId].ShortName.CyrillicToLatin();
			if (_items[itemId].Description != null) _items[itemId].Description = _items[itemId].Description.CyrillicToLatin();
		}
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
	public Item GetItem<T>(Func<Item, T> ratingFunction) where T : IComparable
	{
		var rf = ratingFunction;
		return _items.Values.Aggregate((agg, next) => rf(next).CompareTo(rf(agg)) > 0 ? next : agg).DeepClone();
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
	[Obsolete("This method is deprecated as of EfT 0.12.11.2.13615, use ParseItemCacheHashIndex")]
	public Dictionary<int, (Item item, ItemExtraInfo itemExtraInfo)> ParseItemCacheIndex(string filepath)
	{
		return CacheIndexParserInstance.Parse(filepath);
	}

	/// <summary>
	/// Parse a item cache hash index file into a dictionary of <see cref="Item"/> and <see cref="ItemExtraInfo"/>
	/// </summary>
	/// <param name="filepath">The path to the cache index file</param>
	/// <returns>The parsed cache index</returns>
	/// <remarks>The returned dictionary will only include single items</remarks>
	public Dictionary<int, (Item item, ItemExtraInfo itemExtraInfo)> ParseItemCacheHashIndex(string filepath)
	{
		return CacheHashIndexParserInstance.Parse(filepath);
	}
}
