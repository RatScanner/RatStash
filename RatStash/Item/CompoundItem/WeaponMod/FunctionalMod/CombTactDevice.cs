namespace RatStash
{
	using Newtonsoft.Json;

	public class CombTactDevice
    {
        [JsonProperty("ModesCount")]
        public int ModesCount { get; set; }
    }
}
