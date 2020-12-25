namespace RatStash
{
	using Newtonsoft.Json;

	public class LootContainer
    {
        [JsonProperty("SpawnFilter")]
        public object[] SpawnFilter { get; set; }
    }
}
