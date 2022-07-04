namespace RatStash;

public class Key : Item
{
	[JsonProperty("MaximumNumberOfUsage")]
	public int MaximumNumberOfUsage { get; set; }
}