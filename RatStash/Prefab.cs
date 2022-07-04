using Newtonsoft.Json;

namespace RatStash;

public class Prefab
{
	[JsonProperty("path")]
	public string Path { get; set; }

	[JsonProperty("rcid")]
	public string RcId { get; set; }
}