namespace RatStash
{
	using Newtonsoft.Json;

	public class SearchableItem
    {
        [JsonProperty("BlocksArmorVest")]
        public bool BlocksArmorVest { get; set; }

        [JsonProperty("SearchSound")]
        public string SearchSound { get; set; }
    }
}
