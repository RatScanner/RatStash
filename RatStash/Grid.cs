using System.Collections.Generic;
using Newtonsoft.Json;

namespace RatStash
{
	public class Grid
	{
		[JsonProperty("cellsH")]
		public int CellsHorizontal { get; set; }

		[JsonProperty("cellsV")]
		public int CellsVertical { get; set; }

		[JsonProperty("minCount")]
		public int MinCount { get; set; }

		[JsonProperty("maxCount")]
		public int MaxCount { get; set; }

		[JsonProperty("maxWeight")]
		public int MaxWeight { get; set; }

		[JsonProperty("filters")]
		public List<ItemFilter> Filters { get; set; } = new();
	}
}
