namespace RatStash;

using Newtonsoft.Json;

public class Stock : GearMod
{
	[JsonProperty("Foldable")]
	public bool Foldable { get; set; }

	[JsonProperty("IsShoulderContact")]
	public bool IsShoulderContact { get; set; }

	[JsonProperty("Retractable")]
	public bool Retractable { get; set; }

	[JsonProperty("SizeReduceRight")]
	public int SizeReduceRight { get; set; }
}