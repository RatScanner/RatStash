namespace RatStash
{
	using Newtonsoft.Json;

	public class CombTactDevice : FunctionalMod
	{
		[JsonProperty("ModesCount")]
		public int ModesCount { get; set; }
	}
}
