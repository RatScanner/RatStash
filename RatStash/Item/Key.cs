namespace RatStash
{
	using Newtonsoft.Json;

	public class Key
    {
        [JsonProperty("MaximumNumberOfUsage")]
        public int MaximumNumberOfUsage { get; set; }
    }
}
