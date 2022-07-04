namespace RatStash;

using Newtonsoft.Json;

public class Map : Item
{
	[JsonProperty("ConfigPathStr")]
	public string ConfigPathStr { get; set; }

	[JsonProperty("MaxMarkersCount")]
	public int MaxMarkersCount { get; set; }

	[JsonProperty("scaleMax")]
	public float ScaleMax { get; set; }

	[JsonProperty("scaleMin")]
	public float ScaleMin { get; set; }
}