using System.Collections.Generic;
using System.Dynamic;
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
		public List<StackSlot> Cartridges { get; set; } = new List<StackSlot>();

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

		/// <summary>
		/// Maximum visible ammunition
		/// </summary>
		/// <returns>Maximum visible ammunition of this item</returns>
		public int GetMaxVisibleAmmo() => GetMaxVisibleAmmo(Cartridges.Count);

		/// <summary>
		/// Maximum visible ammunition
		/// </summary>
		/// <param name="cartridgeCount">Override cartridge count</param>
		/// <returns>Maximum visible ammunition of this item</returns>
		public int GetMaxVisibleAmmo(int cartridgeCount)
		{
			var visibleAmmoRanges = GetVisibleAmmoRanges();

			var i = 0;
			while (i < visibleAmmoRanges.Count)
			{
				var (start, end) = visibleAmmoRanges[i];
				if (start <= cartridgeCount && end >= cartridgeCount) return cartridgeCount;
				if (cartridgeCount >= start) i++;
				else return i != 0 ? visibleAmmoRanges[i - 1].end : start;
			}

			return visibleAmmoRanges[visibleAmmoRanges.Count - 1].end;
		}

		/// <summary>
		/// Deconstruct <see cref="VisibleAmmoRangesString"/>
		/// </summary>
		/// <returns>List of tuples of the start and end indexes</returns>
		public List<(int start, int end)> GetVisibleAmmoRanges()
		{
			if (string.IsNullOrEmpty(VisibleAmmoRangesString) || string.IsNullOrWhiteSpace(VisibleAmmoRangesString))
			{
				return new List<(int start, int end)>() { (1, 2) };
			}

			var ranges = new List<(int start, int end)>();
			var splits = VisibleAmmoRangesString.Split(';');
			foreach (var split in splits)
			{
				var range = split.Split('-');
				ranges.Add((int.Parse(range[0]), int.Parse(range[1])));
			}
			return ranges;
		}
	}
}
