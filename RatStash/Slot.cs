using Newtonsoft.Json;

namespace RatStash
{
	public class Slot
	{
		[JsonProperty("filters")]
		public ItemFilter[] Filters { get; set; }
	}
}
