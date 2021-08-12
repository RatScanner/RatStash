namespace RatStash
{
	using Newtonsoft.Json;

	public class Shotgun : Weapon
	{
		[JsonProperty("ShotgunDispersion")]
		public float ShotgunDispersion { get; set; }
	}
}
