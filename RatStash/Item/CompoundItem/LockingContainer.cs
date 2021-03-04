using System.Collections.Generic;

namespace RatStash
{
	using Newtonsoft.Json;

	public class LockingContainer : CompoundItem
	{
		[JsonProperty("KeyIds")]
		public List<string> KeyIds { get; set; } = new List<string>();

		[JsonProperty("TagColor")]
		public int TagColor { get; set; }

		[JsonProperty("TagName")]
		public string TagName { get; set; }
	}
}
