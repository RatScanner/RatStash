using System.Collections.Generic;
using Newtonsoft.Json.Converters;

namespace RatStash;

public class ChestRig : SearchableItem
{
	[JsonProperty("ArmorMaterial")]
	[JsonConverter(typeof(StringEnumConverter))]
	public ArmorMaterial ArmorMaterial { get; set; }

	[JsonProperty("ArmorType")]
	[JsonConverter(typeof(StringEnumConverter))]
	public ArmorType ArmorType { get; set; }

	[JsonProperty("BluntThroughput")]
	public float BluntThroughput { get; set; }

	[JsonProperty("Durability")]
	public int Durability { get; set; }

	[JsonProperty("MaxDurability")]
	public int MaxDurability { get; set; }

	[JsonProperty("RigLayoutName")]
	public string RigLayoutName { get; set; } = "";

	[JsonProperty("armorClass")]
	public int ArmorClass { get; set; }

	[JsonProperty("armorZone", ItemConverterType = typeof(StringEnumConverter))]
	public List<ArmorZone> ArmorZone { get; set; } = new();

	[JsonProperty("armorColliders", ItemConverterType = typeof(StringEnumConverter))]
	public List<ArmorCollider> ArmorColliders { get; set; } = new();

	[JsonProperty("armorPlateColliders", ItemConverterType = typeof(StringEnumConverter))]
	public List<ArmorCollider> ArmorPlateColliders { get; set; } = new();

	[JsonProperty("mousePenalty")]
	public int MousePenalty { get; set; }

	[JsonProperty("speedPenaltyPercent")]
	public int SpeedPenaltyPercent { get; set; }

	[JsonProperty("weaponErgonomicPenalty")]
	public int WeaponErgonomicPenalty { get; set; }

	public List<ArmorCollider> GetArmorColliders()
	{
		List<ArmorCollider> result = new List<ArmorCollider>();
		foreach (var slot in Slots)
		{
			result.AddRange(slot.Filters[0].ArmorColliders);
		}
		return result;
	}
	public List<ArmorPlateCollider> GetArmorPlateColliders()
	{
		List<ArmorPlateCollider> result = new List<ArmorPlateCollider>();
		foreach (var slot in Slots)
		{
			result.AddRange(slot.Filters[0].ArmorPlateColliders);
		}
		return result;
	}
}
