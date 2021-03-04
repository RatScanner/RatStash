using System.Collections.Generic;
using Newtonsoft.Json;

namespace RatStash
{
	[JsonConverter(typeof(JsonPathConverter))]
	public class Slot
	{
		[JsonProperty("_name")]
		public string Name { get; set; }

		[JsonProperty("_props.filters")]
		public List<ItemFilter> Filters { get; set; } = new List<ItemFilter>();

		public Item ContainedItem { get; set; }

		public Item ParentItem { get; set; }
	}
}
