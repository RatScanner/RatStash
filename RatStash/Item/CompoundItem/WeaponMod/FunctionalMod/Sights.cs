namespace RatStash
{
	using Newtonsoft.Json;
	using System.Collections.Generic;

	public class Sights : FunctionalMod
	{
		[JsonProperty("AimSensitivity")]
		public AimSensitivity AimSensitivity { get; set; }

		[JsonProperty("CalibrationDistances")]
		public CalibrationDistances CalibrationDistances { get; set; }

		[JsonProperty("ModesCount")]
		public ModesCount ModesCount { get; set; }

		[JsonProperty("OpticCalibrationDistances")]
		public Dictionary<string, long> OpticCalibrationDistances { get; set; }

		[JsonProperty("ScopesCount")]
		public int ScopesCount { get; set; }

		[JsonProperty("SightModesCount")]
		public int SightModesCount { get; set; }

		[JsonProperty("SightingRange")]
		public int SightingRange { get; set; }

		[JsonProperty("Zooms")]
		public AimSensitivity Zooms { get; set; }

		[JsonProperty("aimingSensitivity")]
		public decimal AimingSensitivity { get; set; }

		[JsonProperty("sightModType")]
		public string SightModType { get; set; }
	}

	public class AimSensitivity
	{
		[JsonProperty("0")]
		public ModesCount The0 { get; set; }
	}

	public class ModesCount
	{
		[JsonProperty("0")]
		public int The0 { get; set; }
	}

	public class CalibrationDistances
	{
		[JsonProperty("0")]
		public Dictionary<string, long> The0 { get; set; }
	}
}
