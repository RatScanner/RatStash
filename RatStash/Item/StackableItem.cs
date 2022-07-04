namespace RatStash;

using Newtonsoft.Json;

public class StackableItem : Item
{
	[JsonProperty("StackMaxRandom")]
	public int StackMaxRandom { get; set; }

	[JsonProperty("StackMinRandom")]
	public int StackMinRandom { get; set; }
}