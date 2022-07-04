using System.Collections.Generic;

namespace RatStash;

public class LootContainer : SearchableItem
{
	[JsonProperty("SpawnFilter")]
	public List<object> SpawnFilter { get; set; } = new();
}