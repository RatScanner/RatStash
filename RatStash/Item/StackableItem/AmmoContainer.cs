namespace RatStash
{
	using Newtonsoft.Json;

	public class AmmoContainer : StackableItem
	{
		[JsonProperty("StackSlots")]
		public object[] StackSlots { get; set; }

		[JsonProperty("ammoCaliber")]
		public string AmmoCaliber { get; set; }
	}
}
