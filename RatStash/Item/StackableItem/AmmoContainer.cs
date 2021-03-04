using System.Collections.Generic;

namespace RatStash
{
	using Newtonsoft.Json;

	public class AmmoContainer : StackableItem
	{
		[JsonProperty("StackSlots")]
		public List<object> StackSlots { get; set; } = new List<object>();

		[JsonProperty("ammoCaliber")]
		public string AmmoCaliber { get; set; }
	}
}
