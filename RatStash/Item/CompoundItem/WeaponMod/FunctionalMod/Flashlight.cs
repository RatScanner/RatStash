namespace RatStash
{
	using Newtonsoft.Json;

	public class Flashlight : FunctionalMod
	{
		[JsonProperty("ModesCount")]
		public int ModesCount { get; set; }
	}
}
