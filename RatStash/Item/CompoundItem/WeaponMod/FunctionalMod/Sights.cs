using System.Collections.Generic;
using Newtonsoft.Json.Converters;

namespace RatStash
{
	using Newtonsoft.Json;

	public class Sights : FunctionalMod
	{
		[JsonProperty("AimSensitivity")]
		public List<List<float>> AimSensitivity { get; set; } = new();

		[JsonProperty("CalibrationDistances")]
		public List<List<int>> CalibrationDistances { get; set; } = new();

		[JsonProperty("ModesCount")]
		public List<int> ModesCount { get; set; } = new();

		[JsonProperty("OpticCalibrationDistances")]
		public List<int> OpticCalibrationDistances { get; set; } = new();

		[JsonProperty("ScopesCount")]
		public int ScopesCount { get; set; }

		[JsonProperty("SightModesCount")]
		public int SightModesCount { get; set; }

		[JsonProperty("Zooms")]
		public List<List<int>> Zooms { get; set; } = new();

		[JsonProperty("aimingSensitivity")]
		public float AimingSensitivity { get; set; }

		[JsonProperty("sightModType")]
		[JsonConverter(typeof(StringEnumConverter))]
		public SightModType SightModType { get; set; }
	}
}
