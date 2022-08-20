namespace RatStash;

public class Barrel : EssentialMod
{
	[JsonProperty("CenterOfImpact")]
	public float CenterOfImpact { get; set; }

	[JsonProperty("IsSilencer")]
	public bool IsSilencer { get; set; }

	[JsonProperty("ShotgunDispersion")]
	public float ShotgunDispersion { get; set; }

	[JsonProperty("DeviationMax")]
	public float DeviationMax { get; set; }

	[JsonProperty("DeviationCurve")]
	public float DeviationCurve { get; set; }
}
