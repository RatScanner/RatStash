namespace RatStash;

public class BarterItem : Item
{
	[JsonProperty("MaxResource")]
	public int MaxResource { get; set; }

	[JsonProperty("Resource")]
	public int Resource { get; set; }
}