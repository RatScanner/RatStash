using Newtonsoft.Json;

namespace RatStash
{
	public class ItemFilter
	{
		[JsonProperty("Filter")]
		public string[] Whitelist { get; set; }

		[JsonProperty("ExcludedFilter")]
		public string[] Blacklist { get; set; }
	}
}
