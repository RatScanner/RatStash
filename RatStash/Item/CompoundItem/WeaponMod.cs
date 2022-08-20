namespace RatStash;

public class WeaponMod : CompoundItem
{
	[JsonProperty("Accuracy")]
	public int Accuracy { get; set; }

	[JsonProperty("DoubleActionAccuracyPenaltyMult")]	
	public float DoubleActionAccuracyPenaltyMultiplier { get; set; }

	[JsonProperty("BlocksCollapsible")]
	public bool BlocksCollapsible { get; set; }

	[JsonProperty("BlocksFolding")]
	public bool BlocksFolding { get; set; }

	[JsonProperty("Durability")]
	public int Durability { get; set; }

	[JsonProperty("EffectiveDistance")]
	public int EffectiveDistance { get; set; }

	[JsonProperty("Ergonomics")]
	public float Ergonomics { get; set; }

	[JsonProperty("HasShoulderContact")]
	public bool HasShoulderContact { get; set; }

	[JsonProperty("IsAnimated")]
	public bool IsAnimated { get; set; }

	[JsonProperty("Loudness")]
	public float Loudness { get; set; }

	[JsonProperty("RaidModdable")]
	public bool RaidModdable { get; set; }

	[JsonProperty("Recoil")]
	public float Recoil { get; set; }

	[JsonProperty("SightingRange")]
	public float SightingRange { get; set; }

	[JsonProperty("ToolModdable")]
	public bool ToolModdable { get; set; }

	[JsonProperty("Velocity")]
	public float Velocity { get; set; }

	[JsonProperty("DurabilityBurnModificator")]
	public float DurabilityBurnModificator { get; set; } = 1f;

	[JsonProperty("HeatFactor")]
	public float HeatFactor { get; set; } = 1f;

	[JsonProperty("CoolFactor")]
	public float CoolFactor { get; set; } = 1f;
}
