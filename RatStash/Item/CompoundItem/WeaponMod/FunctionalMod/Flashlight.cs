namespace RatStash
{
	using Newtonsoft.Json;

	public class Flashlight
    {
        [JsonProperty("ModesCount")]
        public int ModesCount { get; set; }
    }
}
