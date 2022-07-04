namespace RatStash;

public class NightVision : SpecialScope
{
	[JsonProperty("Intensity")]
	public float Intensity { get; set; }

	[JsonProperty("Mask")]
	public Mask Mask { get; set; }

	[JsonProperty("MaskSize")]
	public float MaskSize { get; set; }

	[JsonProperty("NoiseIntensity")]
	public float NoiseIntensity { get; set; }

	[JsonProperty("NoiseScale")]
	public float NoiseScale { get; set; }

	[JsonProperty("Color")]
	public Color Color { get; set; }

	[JsonProperty("DiffuseIntensity")]
	public float DiffuseIntensity { get; set; }

	[JsonProperty("HasHinge")]
	public bool HasHinge { get; set; }
}