namespace RatStash;

using Newtonsoft.Json;

public class Key : Item
{
	[JsonProperty("MaximumNumberOfUsage")]
	public int MaximumNumberOfUsage { get; set; }
}