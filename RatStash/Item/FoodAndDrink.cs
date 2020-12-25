using Newtonsoft.Json.Converters;

namespace RatStash
{
	using Newtonsoft.Json;

	public class FoodAndDrink
    {
        [JsonProperty("MaxResource")]
        public int MaxResource { get; set; }

        [JsonProperty("StimulatorBuffs")]
        public string StimulatorBuffs { get; set; }

        [JsonProperty("foodEffectType")]
		[JsonConverter(typeof(StringEnumConverter))]
        public EffectType FoodEffectType { get; set; }

        [JsonProperty("foodUseTime")]
        public int FoodUseTime { get; set; }
    }
}
