namespace RatStash
{
	using Newtonsoft.Json;

	public class LockingContainer : CompoundItem
	{
		[JsonProperty("KeyIds")]
		public string[] KeyIds { get; set; }

		[JsonProperty("TagColor")]
		public int TagColor { get; set; }

		[JsonProperty("TagName")]
		public string TagName { get; set; }
	}
}
