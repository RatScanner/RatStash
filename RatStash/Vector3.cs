using Newtonsoft.Json;

namespace RatStash
{
	public class Vector3
	{
		[JsonProperty("x")]
		public float X { get; set; }

		[JsonProperty("y")]
		public float Y { get; set; }

		[JsonProperty("z")]
		public float Z { get; set; }
	}
}
