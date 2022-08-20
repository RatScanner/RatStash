using System.Collections.Generic;

namespace RatStash;

[JsonConverter(typeof(JsonPathConverter))]
public class Slot : RawItem<object>, IContainer
{
	[JsonProperty("_props.filters")]
	public List<ItemFilter> Filters { get; set; } = new();

	[JsonProperty("_required")]
	public bool Required { get; set; }

	[JsonProperty("_mergeSlotWithChildren")]
	public bool MergeSlotWithChildren { get; set; }

	public Item ContainedItem { get; set; }

	public Item ParentItem { get; set; }

	public IEnumerable<Item> Items => new[] { ContainedItem };
}
