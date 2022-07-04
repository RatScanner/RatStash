using System.Collections.Generic;

namespace RatStash;

using Newtonsoft.Json;

public class AmmoContainer : StackableItem
{
	[JsonProperty("StackSlots")]
	public List<StackSlot> StackSlots { get; set; } = new();

	[JsonProperty("ammoCaliber")]
	public string AmmoCaliber { get; set; }
}