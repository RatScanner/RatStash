using System.Collections.Generic;
using Newtonsoft.Json.Converters;

namespace RatStash;

public class ArmoredEquipment : Equipment
{
	[JsonProperty("ArmorMaterial")]
	public ArmorMaterial ArmorMaterial { get; set; }

	[JsonProperty("ArmorType")]
	[JsonConverter(typeof(StringEnumConverter))]
	public ArmorType ArmorType { get; set; }

	[JsonProperty("BlindnessProtection")]
	public float BlindnessProtection { get; set; }

	[JsonProperty("BluntThroughput")]
	public float BluntThroughput { get; set; }

	[JsonProperty("DeafStrength")]
	public DeafStrength DeafStrength { get; set; }

	[JsonProperty("Durability")]
	public int Durability { get; set; }

	[JsonProperty("FaceShieldComponent")]
	public bool FaceShieldComponent { get; set; }

	[JsonProperty("FaceShieldMask")]
	public FaceShieldMask FaceShieldMask { get; set; }

	[JsonProperty("HasHinge")]
	public bool HasHinge { get; set; }

	[JsonProperty("Indestructibility")]
	public float Indestructibility { get; set; }

	[JsonProperty("MaterialType")]
	public MaterialType MaterialType { get; set; }

	[JsonProperty("MaxDurability")]
	public int MaxDurability { get; set; }

	[JsonProperty("RicochetParams")]
	public RicochetParams RicochetParams { get; set; }

	[JsonProperty("armorClass")]
	public int ArmorClass { get; set; }

	[JsonProperty("armorZone", ItemConverterType = typeof(StringEnumConverter))]
	public List<ArmorZone> ArmorZone { get; set; } = new();

	[JsonProperty("headSegments", ItemConverterType = typeof(StringEnumConverter))]
	public List<HeadSegment> HeadSegments { get; set; } = new();

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
		foreach(var slot in Slots)
		{
			result.AddRange(slot.Filters[0].ArmorColliders);
		}
		return result;
	}
	public List<ArmorPlateCollider> GetArmorPlateColliders()
	{
		List<ArmorPlateCollider> result = new List<ArmorPlateCollider>();
		foreach(var slot in Slots)
		{
			result.AddRange(slot.Filters[0].ArmorPlateColliders);
		}
		return result;
	}
}

public class RicochetParams
{
	[JsonProperty("x")]
	public int X { get; set; }

	[JsonProperty("y")]
	public int Y { get; set; }

	[JsonProperty("z")]
	public int Z { get; set; }
}
