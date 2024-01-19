using System.Collections.Generic;

namespace RatStash;

public class ItemFilter
{
	[JsonProperty("locked")]
	public bool Locked { get; set; } = new();

	[JsonProperty("Plate")]
	public string PlateId { get; set; } = "";

	[JsonProperty("armorColliders")]
	public List<ArmorCollider> ArmorColliders { get; set; } = new();

	[JsonProperty("armorPlateColliders")]
	public List<ArmorPlateCollider> ArmorPlateColliders { get; set; } = new();

	[JsonProperty("Filter")]
	public List<string> Whitelist { get; set; } = new();

	[JsonProperty("ExcludedFilter")]
	public List<string> Blacklist { get; set; } = new();

	[JsonProperty("Shift")]
	public int Shift { get; set; }

	[JsonProperty("MaxStackCount")]
	public int MaxStackCount { get; set; }

	[JsonProperty("AnimationIndex")]
	public int AnimationIndex { get; set; }
}
