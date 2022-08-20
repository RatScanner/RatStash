using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace RatStash;

public class Meds : Item
{
	[JsonProperty("MaxHpResource")]
	public int MaxHpResource { get; set; }

	[JsonProperty("StimulatorBuffs")]
	public string StimulatorBuffs { get; set; } = "";

	[JsonProperty("hpResourceRate")]
	public int HpResourceRate { get; set; }

	[JsonProperty("medEffectType")]
	[JsonConverter(typeof(StringEnumConverter))]
	public EffectType MedEffectType { get; set; }

	[JsonProperty("medUseTime")]
	public float MedUseTime { get; set; }

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
