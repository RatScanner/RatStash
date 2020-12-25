namespace RatStash
{
	using Newtonsoft.Json;

	public class Shotgun
    {
        [JsonProperty("ShotgunDispersion")]
        public int ShotgunDispersion { get; set; }
    }
}
