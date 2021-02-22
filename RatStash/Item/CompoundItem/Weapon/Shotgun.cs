namespace RatStash
{
	using Newtonsoft.Json;

	public class Shotgun : Weapon
	{
		[JsonProperty("ShotgunDispersion")]
		public int ShotgunDispersion { get; set; }
	}
}
