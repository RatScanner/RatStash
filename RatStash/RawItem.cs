namespace RatStash;

public class RawItem<T>
{
	[JsonProperty("_id")]
	public string Id { get; set; } = "";

	[JsonProperty("_name")]
	public string Name { get; set; } = "";

	[JsonProperty("_parent")]
	public string Parent { get; set; } = "";

	[JsonProperty("_props")]
	public T Props { get; set; }

	[JsonProperty("_proto")]
	public string Proto { get; set; } = "";
}
