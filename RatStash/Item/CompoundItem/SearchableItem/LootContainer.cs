using System.Collections.Generic;

namespace RatStash
{
	using Newtonsoft.Json;

	public class LootContainer : SearchableItem
	{
		[JsonProperty("SpawnFilter")]
		public List<object> SpawnFilter { get; set; } = new List<object>();
	}
}
