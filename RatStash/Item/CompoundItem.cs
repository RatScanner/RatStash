using System.Collections.Generic;

namespace RatStash
{
	using Newtonsoft.Json;

	public class CompoundItem : Item
	{
		[JsonProperty("CanPutIntoDuringTheRaid")]
		public bool CanPutIntoDuringTheRaid { get; set; }

		[JsonProperty("CantRemoveFromSlotsDuringRaid")]
		public List<EquipmentSlot> CantRemoveFromSlotsDuringRaid { get; set; } = new List<EquipmentSlot>();

		[JsonProperty("Grids")]
		public List<Grid> Grids { get; set; } = new List<Grid>();

		[JsonProperty("Slots")]
		public List<Slot> Slots { get; set; } = new List<Slot>();
	}
}
