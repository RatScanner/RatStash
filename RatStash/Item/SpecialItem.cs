namespace RatStash;

public class SpecialItem : Item
{
	[JsonProperty("apResource")]
	public int ApResource { get; set; }

	[JsonProperty("krResource")]
	public int KrResource { get; set; }
}