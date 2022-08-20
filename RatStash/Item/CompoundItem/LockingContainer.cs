using System.Collections.Generic;

namespace RatStash;

public class LockingContainer : CompoundItem
{
	[JsonProperty("KeyIds")]
	public List<string> KeyIds { get; set; } = new();

	[JsonProperty("TagColor")]
	public int TagColor { get; set; }

	[JsonProperty("TagName")]
	public string TagName { get; set; } = "";
}