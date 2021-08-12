using System.Collections.Generic;
using Newtonsoft.Json;

namespace RatStash
{
	[JsonConverter(typeof(JsonPathConverter))]
	public class StackSlot : IContainer
	{
		[JsonProperty("_name")]
		public string Name { get; set; }

		[JsonProperty("_id")]
		public string Id { get; set; }

		[JsonProperty("_max_count")]
		public int MaxCount { get; set; }

		[JsonProperty("_props.filters")]
		public List<ItemFilter> Filters { get; set; } = new();

		public Item ContainedItem { get; set; }

		public Item ParentItem { get; set; }

		public IEnumerable<Item> Items => new[] { ContainedItem };
	}
}
