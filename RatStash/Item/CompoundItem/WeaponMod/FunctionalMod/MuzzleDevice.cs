namespace RatStash
{
	using Newtonsoft.Json;

	public class MuzzleDevice : FunctionalMod
	{
		[JsonProperty("muzzleModType")]
		public string MuzzleModType { get; set; }
	}
}
