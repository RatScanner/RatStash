using System.Collections.Generic;
using Newtonsoft.Json.Converters;

namespace RatStash;

public class Item
{
	public string Id { get; set; } = "";

	[JsonProperty("Name")]
	public string Name { get; set; } = "";

	[JsonProperty("ShortName")]
	public string ShortName { get; set; } = "";

	[JsonProperty("Description")]
	public string Description { get; set; } = "";

	[JsonProperty("Weight")]
	public float Weight { get; set; }

	[JsonProperty("BackgroundColor")]
	[JsonConverter(typeof(StringEnumConverter))]
	public TaxonomyColor BackgroundColor { get; set; }

	[JsonProperty("Width")]
	public int Width { get; set; }

	[JsonProperty("Height")]
	public int Height { get; set; }

	[JsonProperty("StackMaxSize")]
	public int StackMaxSize { get; set; }

	[JsonProperty("Rarity")]
	[JsonConverter(typeof(StringEnumConverter))]
	public Rarity Rarity { get; set; }

	[JsonProperty("DropSoundType")]
	[JsonConverter(typeof(StringEnumConverter))]
	public ItemDropSoundType DropSoundType { get; set; }

	[JsonProperty("SpawnChance")]
	public float SpawnChance { get; set; }

	[JsonProperty("ItemSound")]
	public string ItemSound { get; set; } = "";

	[JsonProperty("Prefab")]
	public Prefab Prefab { get; set; }

	[JsonProperty("UsePrefab")]
	public Prefab UsePrefab { get; set; }

	[JsonProperty("StackObjectsCount")]
	public int StackObjectsCount { get; set; }

	[JsonProperty("NotShownInSlot")]
	public bool NotShownInSlot { get; set; }

	[JsonProperty("ExaminedByDefault")]
	public bool ExaminedByDefault { get; set; }

	[JsonProperty("ExamineTime")]
	public int ExamineTime { get; set; }

	[JsonProperty("IsUndiscardable")]
	public bool IsUndiscardable { get; set; }

	[JsonProperty("IsUnsaleable")]
	public bool IsUnsaleable { get; set; }

	[JsonProperty("IsUnbuyable")]
	public bool IsUnbuyable { get; set; }

	[JsonProperty("IsUngivable")]
	public bool IsUngivable { get; set; }

	[JsonProperty("IsLockedafterEquip")]
	public bool IsLockedafterEquip { get; set; }

	[JsonProperty("QuestItem")]
	public bool QuestItem { get; set; }

	[JsonProperty("LootExperience")]
	public int LootExperience { get; set; }

	[JsonProperty("ExamineExperience")]
	public int ExamineExperience { get; set; }

	[JsonProperty("HideEntrails")]
	public bool HideEntrails { get; set; }

	[JsonProperty("RepairCost")]
	public int RepairCost { get; set; }

	[JsonProperty("RepairSpeed")]
	public int RepairSpeed { get; set; }

	[JsonProperty("ExtraSizeLeft")]
	public int ExtraSizeLeft { get; set; }

	[JsonProperty("ExtraSizeRight")]
	public int ExtraSizeRight { get; set; }

	[JsonProperty("ExtraSizeUp")]
	public int ExtraSizeUp { get; set; }

	[JsonProperty("ExtraSizeDown")]
	public int ExtraSizeDown { get; set; }

	[JsonProperty("ExtraSizeForceAdd")]
	public bool ExtraSizeForceAdd { get; set; }

	[JsonProperty("MergesWithChildren")]
	public bool MergesWithChildren { get; set; }

	[JsonProperty("CanSellOnRagfair")]
	public bool CanSellOnRagfair { get; set; }

	[JsonProperty("CanRequireOnRagfair")]
	public bool CanRequireOnRagfair { get; set; }

	[JsonProperty("ConflictingItems")]
	public List<string> ConflictingItems { get; set; } = new();

	[JsonProperty("FixedPrice")]
	public bool FixedPrice { get; set; }

	[JsonProperty("Unlootable")]
	public bool Unlootable { get; set; }

	[JsonProperty("UnlootableFromSlot")]
	[JsonConverter(typeof(StringEnumConverter))]
	public EquipmentSlot UnlootableFromSlot { get; set; }

	[JsonProperty("UnlootableFromSide", ItemConverterType = typeof(StringEnumConverter))]
	public List<FactionSide> UnlootableFromSide { get; set; }

	[JsonProperty("ChangePriceCoef")]
	public float ChangePriceCoefficient { get; set; }

	[JsonProperty("AllowSpawnOnLocations", ItemConverterType = typeof(StringEnumConverter))]
	public List<Location> AllowSpawnOnLocations { get; set; }

	[JsonProperty("SendToClient")]
	public bool SendToClient { get; set; }

	[JsonProperty("AnimationVariantsNumber")]
	public int AnimationVariantsNumber { get; set; }

	[JsonProperty("DiscardingBlock")]
	public bool DiscardingBlock { get; set; }

	[JsonProperty("RagFairCommissionModifier")]
	public float RagFairCommissionModifier { get; set; } = 1f;

	[JsonProperty("IsAlwaysAvailableForInsurance")]
	public bool IsAlwaysAvailableForInsurance { get; set; }

	[JsonProperty("DiscardLimit")]
	public int DiscardLimit { get; set; } = -1;

	/// <summary>
	/// Recursively compute the slot size of the item
	/// </summary>
	/// <returns>Slot size of the item</returns>
	/// <remarks>Ignores reduced size of folded stocks</remarks>
	public (int width, int height) GetSlotSize()
	{
		var recursiveExtraSize = GetExtraSizeRecursive(new ExtraSize());
		return recursiveExtraSize.Apply(Width, Height);
	}

	private ExtraSize GetExtraSizeRecursive(ExtraSize extraSize)
	{
		if (this is CompoundItem compoundItem)
		{
			var slots = compoundItem.Slots;
			foreach (var slot in slots)
			{
				if (slot.ContainedItem == null) continue;
				var subExtraSize = slot.ContainedItem.GetExtraSizeRecursive(extraSize);
				extraSize = ExtraSize.Merge(extraSize, subExtraSize);
			}
		}

		return ExtraSize.Merge(ExtraSize, extraSize);
	}

	public ExtraSize ExtraSize =>
		new ExtraSize()
		{
			Left = ExtraSizeForceAdd ? 0 : ExtraSizeLeft,
			Right = ExtraSizeForceAdd ? 0 : ExtraSizeRight,
			Up = ExtraSizeForceAdd ? 0 : ExtraSizeUp,
			Down = ExtraSizeForceAdd ? 0 : ExtraSizeDown,
			ForcedLeft = ExtraSizeForceAdd ? ExtraSizeLeft : 0,
			ForcedRight = ExtraSizeForceAdd ? ExtraSizeRight : 0,
			ForcedUp = ExtraSizeForceAdd ? ExtraSizeUp : 0,
			ForcedDown = ExtraSizeForceAdd ? ExtraSizeDown : 0,
		};

	public override bool Equals(object obj)
	{
		if ((obj == null) || GetType() != obj.GetType()) return false;

		if (this is CompoundItem thisItem && (Item)obj is CompoundItem otherItem)
		{
			if (thisItem.Slots.Count != otherItem.Slots.Count) return false;
			for (var i = 0; i < thisItem.Slots.Count; i++)
			{
				var thisContainedItem = thisItem.Slots[i].ContainedItem;
				var otherContainedItem = otherItem.Slots[i].ContainedItem;
				if (thisContainedItem == null && otherContainedItem == null) continue;
				if (thisContainedItem == null || otherContainedItem == null) return false;
				if (!thisContainedItem.Equals(otherContainedItem)) return false;
			}
		}

		return Id == ((Item)obj).Id;
	}

	public override int GetHashCode()
	{
		var hashCode = 17 * 29 + Id.GetHashCode();

		if (this is CompoundItem compoundItem)
		{

			foreach (var slot in compoundItem.Slots)
			{
				var item = slot.ContainedItem;
				if (item == null) continue;
				hashCode *= 29 + item.GetHashCode();
			}
		}

		return hashCode;
	}

	public static bool operator ==(Item lhs, Item rhs)
	{
		if (ReferenceEquals(lhs, rhs)) return true;
		if (ReferenceEquals(lhs, null)) return false;
		if (ReferenceEquals(rhs, null)) return false;

		return lhs.Equals(rhs);
	}

	public static bool operator !=(Item lhs, Item rhs) => !(lhs == rhs);
}
