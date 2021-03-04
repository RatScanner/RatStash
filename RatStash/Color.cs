using Newtonsoft.Json;

namespace RatStash
{
	public class Color
	{
		[JsonProperty("r")]
		public int R { get; set; }

		[JsonProperty("g")]
		public int G { get; set; }

		[JsonProperty("b")]
		public int B { get; set; }

		[JsonProperty("a")]
		public int A { get; set; }

		public Color(int red, int green, int blue, int alpha = 0)
		{
			R = red;
			G = green;
			B = blue;
			A = alpha;
		}

		public static implicit operator System.Drawing.Color(Color c)
		{
			return System.Drawing.Color.FromArgb(c.A, c.R, c.G, c.B);
		}

		public static implicit operator Color(System.Drawing.Color c)
		{
			return new Color(c.A, c.R, c.G, c.B);
		}
	}
}
