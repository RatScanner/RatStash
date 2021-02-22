namespace RatStash
{
	using Newtonsoft.Json;

	public class Electronics : BarterItem
	{
		[JsonProperty("MaxResource")]
		public int MaxResource { get; set; }

		[JsonProperty("Resource")]
		public int Resource { get; set; }
	}
}
