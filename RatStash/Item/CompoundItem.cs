namespace RatStash
{
	using Newtonsoft.Json;

	public class CompoundItem : Item
	{
		[JsonProperty("CanPutIntoDuringTheRaid")]
		public bool CanPutIntoDuringTheRaid { get; set; }

		[JsonProperty("CantRemoveFromSlotsDuringRaid")]
		public EquipmentSlot[] CantRemoveFromSlotsDuringRaid { get; set; }

		[JsonProperty("Grids")]
		public Grid[] Grids { get; set; }

		[JsonProperty("Slots")]
		public Slot[] Slots { get; set; }
	}
}
