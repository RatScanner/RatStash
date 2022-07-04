namespace RatStash;

using Newtonsoft.Json;

public class SearchableItem : CompoundItem
{
	[JsonProperty("BlocksArmorVest")]
	public bool BlocksArmorVest { get; set; }

	[JsonProperty("SearchSound")]
	public string SearchSound { get; set; }
}