using Newtonsoft.Json.Converters;

namespace RatStash;

using Newtonsoft.Json;

public class MuzzleDevice : FunctionalMod
{
	[JsonProperty("muzzleModType")]
	[JsonConverter(typeof(StringEnumConverter))]
	public MuzzleModType MuzzleModType { get; set; }
}