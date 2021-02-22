namespace RatStash
{
	using Newtonsoft.Json;

	public class Equipment : CompoundItem
	{
		[JsonProperty("BlocksEarpiece")]
		public bool BlocksEarpiece { get; set; }

		[JsonProperty("BlocksEyewear")]
		public bool BlocksEyewear { get; set; }

		[JsonProperty("BlocksFaceCover")]
		public bool BlocksFaceCover { get; set; }

		[JsonProperty("BlocksHeadwear")]
		public bool BlocksHeadwear { get; set; }
	}
}
