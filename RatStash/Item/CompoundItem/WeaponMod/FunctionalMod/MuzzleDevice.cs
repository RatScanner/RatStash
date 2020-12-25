namespace RatStash
{
	using Newtonsoft.Json;

	public class MuzzleDevice
    {
        [JsonProperty("muzzleModType")]
        public string MuzzleModType { get; set; }
    }
}
