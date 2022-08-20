using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace RatStash;

public class FoodAndDrink : Item
{
	[JsonProperty("MaxResource")]
	public int MaxResource { get; set; }

	[JsonProperty("StimulatorBuffs")]
	public string StimulatorBuffs { get; set; } = "";

	[JsonProperty("foodEffectType")]
	[JsonConverter(typeof(StringEnumConverter))]
	public EffectType FoodEffectType { get; set; }

	[JsonProperty("foodUseTime")]
	public int FoodUseTime { get; set; }


	// TODO
	/// <remarks>
	/// Based on the inability of BSG, this property can either be an Array, Object or none.
	/// A PR for a custom json converter which can handle these cases is very welcome.
	/// </remarks>
	[JsonProperty("effects_health")]
	public JToken EffectsHealth { get; set; }

	// TODO
	/// <remarks>
	/// Based on the inability of BSG, this property can either be an Array, Object or none.
	/// A PR for a custom json converter which can handle these cases is very welcome.
	/// </remarks>
	[JsonProperty("effects_damage")]
	public JToken EffectsDamage { get; set; }
}
