namespace RatStash;

public class Shotgun : Weapon
{
	[JsonProperty("ShotgunDispersion")]
	public float ShotgunDispersion { get; set; }
}