using System.Collections.Generic;

namespace RatStash;

public class Launcher : GearMod
{
	[JsonProperty("LinkedWeapon")]
	public string LinkedWeapon { get; set; } = "";

	[JsonProperty("UseAmmoWithoutShell")]
	public bool UseAmmoWithoutShell { get; set; }

	[JsonProperty("Chambers")]
	public List<Slot> Chambers { get; set; } = new();
}
