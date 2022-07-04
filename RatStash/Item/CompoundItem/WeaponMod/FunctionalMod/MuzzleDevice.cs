using Newtonsoft.Json.Converters;

namespace RatStash;

public class MuzzleDevice : FunctionalMod
{
	[JsonProperty("muzzleModType")]
	[JsonConverter(typeof(StringEnumConverter))]
	public MuzzleModType MuzzleModType { get; set; }
}