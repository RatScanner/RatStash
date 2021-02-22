namespace RatStash
{
	using Newtonsoft.Json;

	public class LootContainer : SearchableItem
	{
		[JsonProperty("SpawnFilter")]
		public object[] SpawnFilter { get; set; }
	}
}
