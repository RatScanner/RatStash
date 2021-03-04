using Newtonsoft.Json;

namespace RatStash
{
	public class CombTactDevice : FunctionalMod
	{
		[JsonProperty("ModesCount")]
		public int ModesCount { get; set; }
	}
}
