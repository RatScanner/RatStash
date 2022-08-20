namespace RatStash;

public class ThrowableWeapon : Item
{
	[JsonProperty("ArmorDistanceDistanceDamage")]
	public Vector3 ArmorDistanceDistanceDamage { get; set; }

	[JsonProperty("Blindness")]
	public Vector3 Blindness { get; set; }

	[JsonProperty("CanBeHiddenDuringThrow")]
	public bool CanBeHiddenDuringThrow { get; set; }

	[JsonProperty("Contusion")]
	public Vector3 Contusion { get; set; }

	[JsonProperty("ContusionDistance")]
	public float ContusionDistance { get; set; }

	[JsonProperty("EmitTime")]
	public int EmitTime { get; set; }

	[JsonProperty("explDelay")]
	public float ExplosionDelay { get; set; }

	[JsonProperty("FragmentType")]
	public string FragmentType { get; set; } = "";

	[JsonProperty("FragmentsCount")]
	public int FragmentsCount { get; set; }

	[JsonProperty("MaxExplosionDistance")]
	public float MaxExplosionDistance { get; set; }

	[JsonProperty("MinExplosionDistance")]
	public float MinExplosionDistance { get; set; }

	[JsonProperty("Strength")]
	public int Strength { get; set; }

	[JsonProperty("ThrowType")]
	public string ThrowType { get; set; } = "";

	[JsonProperty("throwDamMax")]
	public int ThrowDamMax { get; set; }

	[JsonProperty("MinFragmentDamage")]
	public float MinFragmentDamage { get; set; }

	[JsonProperty("MaxFragmentDamage")]
	public float MaxFragmentDamage { get; set; }

	[JsonProperty("MinTimeToContactExplode")]
	public float MinTimeToContactExplode { get; set; } = -1f;

	[JsonProperty("ExplosionEffectType")]
	public string ExplosionEffectType { get; set; } = "";
}
