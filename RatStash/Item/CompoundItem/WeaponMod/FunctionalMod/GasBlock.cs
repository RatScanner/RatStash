using Newtonsoft.Json.Converters;

namespace RatStash;

public class GasBlock : FunctionalMod
{
	[JsonProperty("muzzleModType")]
	[JsonConverter(typeof(StringEnumConverter))]
	public MuzzleModType MuzzleModType;
}
