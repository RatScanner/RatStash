using System.Collections.Generic;
using Newtonsoft.Json.Converters;

namespace RatStash
{
	using Newtonsoft.Json;

	public class PortableContainer : SearchableItem
	{
		[JsonProperty("containType")]
		public List<object> ContainType { get; set; } = new();

		[JsonProperty("isSecured")]
		public bool IsSecured { get; set; }

		[JsonProperty("lootFilter")]
		public List<object> LootFilter { get; set; } = new();

		[JsonProperty("maxCountSpawn")]
		public int MaxCountSpawn { get; set; }

		[JsonProperty("minCountSpawn")]
		public int MinCountSpawn { get; set; }

		[JsonProperty("openedByKeyID")]
		public List<object> OpenedByKeyId { get; set; } = new();

		[JsonProperty("sizeHeight")]
		public int SizeHeight { get; set; }

		[JsonProperty("sizeWidth")]
		public int SizeWidth { get; set; }

		[JsonProperty("spawnRarity")]
		[JsonConverter(typeof(StringEnumConverter))]
		public Rarity SpawnRarity { get; set; }

		[JsonProperty("spawnTypes")]
		public string SpawnTypes { get; set; }
	}
}
