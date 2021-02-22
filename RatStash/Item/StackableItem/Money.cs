namespace RatStash
{
	using Newtonsoft.Json;

	public class Money : StackableItem
	{
		[JsonProperty("eqMax")]
		public long EqMax { get; set; }

		[JsonProperty("eqMin")]
		public long EqMin { get; set; }

		[JsonProperty("rate")]
		public long Rate { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
