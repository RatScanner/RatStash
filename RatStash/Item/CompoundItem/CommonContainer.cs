namespace RatStash
{
	using Newtonsoft.Json;

	public class CommonContainer
    {
        [JsonProperty("TagColor")]
        public int TagColor { get; set; }

        [JsonProperty("TagName")]
        public string TagName { get; set; }
    }
}
