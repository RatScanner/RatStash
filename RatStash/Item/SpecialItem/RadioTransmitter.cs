namespace RatStash;

public class RadioTransmitter : SpecialItem
{
	[JsonProperty("IsEncoded")]
	public bool IsEncoded { get; set; }
}
