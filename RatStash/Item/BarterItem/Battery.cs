namespace RatStash
{
	using Newtonsoft.Json;

	public class Battery
    {
        [JsonProperty("MaxResource")]
        public int MaxResource { get; set; }

        [JsonProperty("Resource")]
        public int Resource { get; set; }
    }
}
