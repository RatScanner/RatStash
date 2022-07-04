namespace RatStash;

public class Backpack : SearchableItem
{
	[JsonProperty("GridLayoutName")]
	public string GridLayoutName { get; set; }

	[JsonProperty("speedPenaltyPercent")]
	public int SpeedPenaltyPercent { get; set; }
}