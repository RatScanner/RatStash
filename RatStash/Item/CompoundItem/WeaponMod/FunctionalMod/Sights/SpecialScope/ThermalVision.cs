namespace RatStash;

public class ThermalVision : SpecialScope
{
	[JsonProperty("RampPalette")]
	public SelectablePalette RampPalette { get; set; }

	[JsonProperty("DepthFade")]
	public float DepthFade { get; set; }

	[JsonProperty("RoughnessCoef")]
	public float RoughnessCoef { get; set; }

	[JsonProperty("SpecularCoef")]
	public float SpecularCoef { get; set; }

	[JsonProperty("MainTexColorCoef")]
	public float MainTexColorCoef { get; set; }

	[JsonProperty("MinimumTemperatureValue")]
	public float MinimumTemperatureValue { get; set; }

	[JsonProperty("RampShift")]
	public float RampShift { get; set; }

	[JsonProperty("HeatMin")]
	public float HeatMin { get; set; }

	[JsonProperty("ColdMax")]
	public float ColdMax { get; set; }

	[JsonProperty("IsNoisy")]
	public bool IsNoisy { get; set; }

	[JsonProperty("NoiseIntensity")]
	public float NoiseIntensity { get; set; }

	[JsonProperty("IsFpsStuck")]
	public bool IsFpsStuck { get; set; }

	[JsonProperty("IsGlitch")]
	public bool IsGlitch { get; set; }

	[JsonProperty("IsMotionBlurred")]
	public bool IsMotionBlurred { get; set; }

	[JsonProperty("Mask")]
	public Mask Mask { get; set; }

	[JsonProperty("MaskSize")]
	public float MaskSize { get; set; }

	[JsonProperty("IsPixelated")]
	public bool IsPixelated { get; set; }

	[JsonProperty("PixelationBlockCount")]
	public int PixelationBlockCount { get; set; }
}