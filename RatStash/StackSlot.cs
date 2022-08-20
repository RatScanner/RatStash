using System.Collections.Generic;

namespace RatStash;

[JsonConverter(typeof(JsonPathConverter))]
public class StackSlot : RawItem<object>, IContainer
{
	[JsonProperty("_max_count")]
	public int MaxCount { get; set; }

	[JsonProperty("_props.filters")]
	public List<ItemFilter> Filters { get; set; } = new();

	public Item ContainedItem { get; set; }

	public Item ParentItem { get; set; }

	public IEnumerable<Item> Items => new[] { ContainedItem };
}
