namespace RatStash
{
	using Newtonsoft.Json;

	public class Barrel : EssentialMod
	{
		[JsonProperty("CenterOfImpact")]
		public decimal CenterOfImpact { get; set; }

		[JsonProperty("IsSilencer")]
		public bool IsSilencer { get; set; }

		[JsonProperty("ShotgunDispersion")]
		public int ShotgunDispersion { get; set; }
	}
}
