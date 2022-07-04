using Newtonsoft.Json;

namespace RatStash;

public class Knife : Item
{
	[JsonProperty("DeflectionConsumption")]
	public int DeflectionConsumption { get; set; }

	[JsonProperty("Durability")]
	public int Durability { get; set; }

	[JsonProperty("MaxDurability")]
	public int MaxDurability { get; set; }

	[JsonProperty("MaxRepairDegradation")]
	public float MaxRepairDegradation { get; set; }

	[JsonProperty("MinRepairDegradation")]
	public float MinRepairDegradation { get; set; }

	[JsonProperty("PrimaryConsumption")]
	public int PrimaryConsumption { get; set; }

	[JsonProperty("PrimaryDistance")]
	public float PrimaryDistance { get; set; }

	[JsonProperty("SecondryConsumption")]
	public int SecondaryConsumption { get; set; }

	[JsonProperty("SecondryDistance")]
	public float SecondaryDistance { get; set; }

	[JsonProperty("SlashPenetration")]
	public int SlashPenetration { get; set; }

	[JsonProperty("StabPenetration")]
	public int StabPenetration { get; set; }

	[JsonProperty("knifeDurab")]
	public int KnifeDurability { get; set; }

	[JsonProperty("knifeHitDelay")]
	public int KnifeHitDelay { get; set; }

	[JsonProperty("knifeHitRadius")]
	public float KnifeHitRadius { get; set; }

	[JsonProperty("knifeHitSlashDam")]
	public int KnifeHitSlashDam { get; set; }

	[JsonProperty("knifeHitSlashRate")]
	public int KnifeHitSlashRate { get; set; }

	[JsonProperty("knifeHitStabDam")]
	public int KnifeHitStabDam { get; set; }

	[JsonProperty("knifeHitStabRate")]
	public int KnifeHitStabRate { get; set; }
}