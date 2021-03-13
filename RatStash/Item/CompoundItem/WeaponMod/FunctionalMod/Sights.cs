using System.Collections.Generic;
using Newtonsoft.Json.Converters;

namespace RatStash
{
	using Newtonsoft.Json;

	public class Sights : FunctionalMod
	{
		[JsonProperty("AimSensitivity")]
		public List<List<float>> AimSensitivity { get; set; } = new List<List<float>>();

		[JsonProperty("CalibrationDistances")]
		public List<List<int>> CalibrationDistances { get; set; } = new List<List<int>>();

		[JsonProperty("ModesCount")]
		public List<int> ModesCount { get; set; } = new List<int>();

		[JsonProperty("OpticCalibrationDistances")]
		public List<int> OpticCalibrationDistances { get; set; } = new List<int>();

		[JsonProperty("ScopesCount")]
		public int ScopesCount { get; set; }

		[JsonProperty("SightModesCount")]
		public int SightModesCount { get; set; }

		[JsonProperty("SightingRange")]
		public int SightingRange { get; set; }

		[JsonProperty("Zooms")]
		public List<List<int>> Zooms { get; set; } = new List<List<int>>();

		[JsonProperty("aimingSensitivity")]
		public float AimingSensitivity { get; set; }

		[JsonProperty("sightModType")]
		[JsonConverter(typeof(StringEnumConverter))]
		public SightModType SightModType { get; set; }
	}
}
