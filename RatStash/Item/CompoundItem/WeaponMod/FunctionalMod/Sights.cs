using Newtonsoft.Json.Converters;

namespace RatStash
{
	using Newtonsoft.Json;

	public class Sights : FunctionalMod
	{
		[JsonProperty("AimSensitivity")]
		public float[][] AimSensitivity { get; set; }

		[JsonProperty("CalibrationDistances")]
		public int[][] CalibrationDistances { get; set; }

		[JsonProperty("ModesCount")]
		public int[] ModesCount { get; set; }

		[JsonProperty("OpticCalibrationDistances")]
		public int[] OpticCalibrationDistances { get; set; }

		[JsonProperty("ScopesCount")]
		public int ScopesCount { get; set; }

		[JsonProperty("SightModesCount")]
		public int SightModesCount { get; set; }

		[JsonProperty("SightingRange")]
		public int SightingRange { get; set; }

		[JsonProperty("Zooms")]
		public int[][] Zooms { get; set; }

		[JsonProperty("aimingSensitivity")]
		public float AimingSensitivity { get; set; }

		[JsonProperty("sightModType")]

		[JsonConverter(typeof(StringEnumConverter))]
		public SightModType SightModType { get; set; }
	}
}
