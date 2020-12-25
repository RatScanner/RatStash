using Newtonsoft.Json.Converters;

namespace RatStash
{
	using Newtonsoft.Json;

	public class Meds
    {
        [JsonProperty("MaxHpResource")]
        public int MaxHpResource { get; set; }

        [JsonProperty("StimulatorBuffs")]
        public string StimulatorBuffs { get; set; }

        [JsonProperty("hpResourceRate")]
        public int HpResourceRate { get; set; }

        [JsonProperty("medEffectType")]
		[JsonConverter(typeof(StringEnumConverter))]
        public EffectType MedEffectType { get; set; }

        [JsonProperty("medUseTime")]
        public float MedUseTime { get; set; }
    }
}
