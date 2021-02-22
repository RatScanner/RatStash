using Newtonsoft.Json.Converters;

namespace RatStash
{
	using Newtonsoft.Json;

	public class Ammo : StackableItem
	{
		[JsonProperty("AmmoLifeTimeSec")]
		public int AmmoLifeTimeSec { get; set; }

		[JsonProperty("ArmorDamage")]
		public int ArmorDamage { get; set; }

		[JsonProperty("ArmorDistanceDistanceDamage")]
		public ArmorDistanceDistanceDamage ArmorDistanceDistanceDamage { get; set; }

		[JsonProperty("BallisticCoeficient")]
		public int BallisticCoeficient { get; set; }

		[JsonProperty("Blindness")]
		public ArmorDistanceDistanceDamage Blindness { get; set; }

		[JsonProperty("Caliber")]
		public string Caliber { get; set; }

		[JsonProperty("Contusion")]
		public ArmorDistanceDistanceDamage Contusion { get; set; }

		[JsonProperty("Damage")]
		public int Damage { get; set; }

		[JsonProperty("Deterioration")]
		public int Deterioration { get; set; }

		[JsonProperty("ExplosionStrength")]
		public int ExplosionStrength { get; set; }

		[JsonProperty("ExplosionType")]
		[JsonConverter(typeof(StringEnumConverter))]
		public ExplosionType ExplosionType { get; set; }

		[JsonProperty("FragmentType")]
		public string FragmentType { get; set; }

		[JsonProperty("FragmentationChance")]
		public int FragmentationChance { get; set; }

		[JsonProperty("FragmentsCount")]
		public int FragmentsCount { get; set; }

		[JsonProperty("FuzeArmTimeSec")]
		public int FuzeArmTimeSec { get; set; }

		[JsonProperty("HasGrenaderComponent")]
		public bool HasGrenaderComponent { get; set; }

		[JsonProperty("HeavyBleedingDelta")]
		public int HeavyBleedingDelta { get; set; }

		[JsonProperty("InitialSpeed")]
		public int InitialSpeed { get; set; }

		[JsonProperty("IsLightAndSoundShot")]
		public bool IsLightAndSoundShot { get; set; }

		[JsonProperty("LightAndSoundShotAngle")]
		public int LightAndSoundShotAngle { get; set; }

		[JsonProperty("LightAndSoundShotSelfContusionStrength")]
		public int LightAndSoundShotSelfContusionStrength { get; set; }

		[JsonProperty("LightAndSoundShotSelfContusionTime")]
		public int LightAndSoundShotSelfContusionTime { get; set; }

		[JsonProperty("LightBleedingDelta")]
		public int LightBleedingDelta { get; set; }

		[JsonProperty("MaxExplosionDistance")]
		public int MaxExplosionDistance { get; set; }

		[JsonProperty("MaxFragmentsCount")]
		public int MaxFragmentsCount { get; set; }

		[JsonProperty("MinExplosionDistance")]
		public int MinExplosionDistance { get; set; }

		[JsonProperty("MinFragmentsCount")]
		public int MinFragmentsCount { get; set; }

		[JsonProperty("MisfireChance")]
		public int MisfireChance { get; set; }

		[JsonProperty("PenetrationChance")]
		public int PenetrationChance { get; set; }

		[JsonProperty("PenetrationPowerDiviation")]
		public int PenetrationPowerDiviation { get; set; }

		[JsonProperty("ProjectileCount")]
		public int ProjectileCount { get; set; }

		[JsonProperty("RicochetChance")]
		public int RicochetChance { get; set; }

		[JsonProperty("ShowBullet")]
		public bool ShowBullet { get; set; }

		[JsonProperty("ShowHitEffectOnExplode")]
		public bool ShowHitEffectOnExplode { get; set; }

		[JsonProperty("SpeedRetardation")]
		public int SpeedRetardation { get; set; }

		[JsonProperty("StaminaBurnPerDamage")]
		public float StaminaBurnPerDamage { get; set; }

		[JsonProperty("TracerColor")]
		[JsonConverter(typeof(StringEnumConverter))]
		public TaxonomyColor TracerColor { get; set; }

		[JsonProperty("TracerDistance")]
		public int TracerDistance { get; set; }

		[JsonProperty("ammoAccr")]
		public int AmmoAccuracy { get; set; }

		[JsonProperty("ammoDist")]
		public int AmmoDistance { get; set; }

		[JsonProperty("ammoHear")]
		public int AmmoHear { get; set; }

		[JsonProperty("ammoRec")]
		public int AmmoRec { get; set; }

		[JsonProperty("ammoSfx")]
		public string AmmoSfx { get; set; }

		[JsonProperty("ammoShiftChance")]
		public int AmmoShiftChance { get; set; }

		[JsonProperty("ammoType")]
		[JsonConverter(typeof(StringEnumConverter))]
		public AmmoType AmmoType { get; set; }

		[JsonProperty("buckshotBullets")]
		public int BuckshotBullets { get; set; }

		[JsonProperty("casingEjectPower")]
		public int CasingEjectPower { get; set; }

		[JsonProperty("casingMass")]
		public int CasingMass { get; set; }

		[JsonProperty("casingName")]
		public string CasingName { get; set; }

		[JsonProperty("casingSounds")]
		public string CasingSounds { get; set; }
	}

	public class ArmorDistanceDistanceDamage
	{
		[JsonProperty("x")]
		public int X { get; set; }

		[JsonProperty("y")]
		public int Y { get; set; }

		[JsonProperty("z")]
		public int Z { get; set; }
	}
}
