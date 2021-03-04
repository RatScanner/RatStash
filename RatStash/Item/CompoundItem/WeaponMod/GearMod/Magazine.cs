using System.Collections.Generic;
using Newtonsoft.Json.Converters;

namespace RatStash
{
	using Newtonsoft.Json;

	public class Magazine : GearMod
	{
		[JsonProperty("CanAdmin")]
		public bool CanAdmin { get; set; }

		[JsonProperty("CanFast")]
		public bool CanFast { get; set; }

		[JsonProperty("CanHit")]
		public bool CanHit { get; set; }

		[JsonProperty("Cartridges")]
		public List<Slot> Cartridges { get; set; } = new List<Slot>();

		[JsonProperty("CheckOverride")]
		public int CheckOverride { get; set; }

		[JsonProperty("CheckTimeModifier")]
		public int CheckTimeModifier { get; set; }

		[JsonProperty("LoadUnloadModifier")]
		public int LoadUnloadModifier { get; set; }

		[JsonProperty("ReloadMagType")]
		[JsonConverter(typeof(StringEnumConverter))]
		public ReloadMode ReloadMagType { get; set; }

		[JsonProperty("VisibleAmmoRangesString")]
		public string VisibleAmmoRangesString { get; set; }

		[JsonProperty("magAnimationIndex")]
		public int MagAnimationIndex { get; set; }
	}
}
