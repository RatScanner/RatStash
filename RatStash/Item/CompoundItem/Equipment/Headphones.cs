namespace RatStash;

using Newtonsoft.Json;

public class Headphones : Equipment
{
	[JsonProperty("AmbientVolume")]
	public int AmbientVolume { get; set; }

	[JsonProperty("CompressorAttack")]
	public int CompressorAttack { get; set; }

	[JsonProperty("CompressorGain")]
	public int CompressorGain { get; set; }

	[JsonProperty("CompressorRelease")]
	public int CompressorRelease { get; set; }

	[JsonProperty("CompressorTreshold")]
	public int CompressorTreshold { get; set; }

	[JsonProperty("CompressorVolume")]
	public int CompressorVolume { get; set; }

	[JsonProperty("CutoffFreq")]
	public int CutoffFreq { get; set; }

	[JsonProperty("Distortion")]
	public float Distortion { get; set; }

	[JsonProperty("DryVolume")]
	public int DryVolume { get; set; }

	[JsonProperty("Resonance")]
	public float Resonance { get; set; }
}