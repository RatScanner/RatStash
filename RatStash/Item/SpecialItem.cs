namespace RatStash
{
	using Newtonsoft.Json;

	public class SpecialItem
    {
        [JsonProperty("apResource")]
        public int ApResource { get; set; }

        [JsonProperty("krResource")]
        public int KrResource { get; set; }
    }
}
