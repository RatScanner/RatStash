namespace RatStash;

using Newtonsoft.Json;

public class Other : BarterItem
{
	[JsonProperty("DogTagQualities")]
	public bool DogTagQualities { get; set; }
}