using Newtonsoft.Json.Converters;

namespace RatStash;

using Newtonsoft.Json;

public class Money : StackableItem
{
	[JsonProperty("eqMax")]
	public int EqMax { get; set; }

	[JsonProperty("eqMin")]
	public int EqMin { get; set; }

	[JsonProperty("rate")]
	public int Rate { get; set; }

	[JsonProperty("type")]
	[JsonConverter(typeof(StringEnumConverter))]
	public Currency Type { get; set; }
}