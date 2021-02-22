namespace RatStash
{
	using Newtonsoft.Json;

	public class Ammo : StackableItem
	{
		[JsonProperty("AmmoLifeTimeSec")]
		public long AmmoLifeTimeSec { get; set; }

		[JsonProperty("ArmorDamage")]
		public long ArmorDamage { get; set; }

		[JsonProperty("ArmorDistanceDistanceDamage")]
		public ArmorDistanceDistanceDamage ArmorDistanceDistanceDamage { get; set; }

		[JsonProperty("BallisticCoeficient")]
		public long BallisticCoeficient { get; set; }

		[JsonProperty("Blindness")]
		public ArmorDistanceDistanceDamage Blindness { get; set; }

		[JsonProperty("Caliber")]
		public string Caliber { get; set; }

		[JsonProperty("Contusion")]
		public ArmorDistanceDistanceDamage Contusion { get; set; }

		[JsonProperty("Damage")]
		public long Damage { get; set; }

		[JsonProperty("Deterioration")]
		public long Deterioration { get; set; }

		[JsonProperty("ExplosionStrength")]
		public long ExplosionStrength { get; set; }

		[JsonProperty("ExplosionType")]
		public string ExplosionType { get; set; }

		[JsonProperty("FragmentType")]
		public string FragmentType { get; set; }

		[JsonProperty("FragmentationChance")]
		public long FragmentationChance { get; set; }

		[JsonProperty("FragmentsCount")]
		public long FragmentsCount { get; set; }

		[JsonProperty("FuzeArmTimeSec")]
		public long FuzeArmTimeSec { get; set; }

		[JsonProperty("HasGrenaderComponent")]
		public bool HasGrenaderComponent { get; set; }

		[JsonProperty("HeavyBleedingDelta")]
		public long HeavyBleedingDelta { get; set; }

		[JsonProperty("InitialSpeed")]
		public long InitialSpeed { get; set; }

		[JsonProperty("IsLightAndSoundShot")]
		public bool IsLightAndSoundShot { get; set; }

		[JsonProperty("LightAndSoundShotAngle")]
		public long LightAndSoundShotAngle { get; set; }

		[JsonProperty("LightAndSoundShotSelfContusionStrength")]
		public long LightAndSoundShotSelfContusionStrength { get; set; }

		[JsonProperty("LightAndSoundShotSelfContusionTime")]
		public long LightAndSoundShotSelfContusionTime { get; set; }

		[JsonProperty("LightBleedingDelta")]
		public long LightBleedingDelta { get; set; }

		[JsonProperty("MaxExplosionDistance")]
		public long MaxExplosionDistance { get; set; }

		[JsonProperty("MaxFragmentsCount")]
		public long MaxFragmentsCount { get; set; }

		[JsonProperty("MinExplosionDistance")]
		public long MinExplosionDistance { get; set; }

		[JsonProperty("MinFragmentsCount")]
		public long MinFragmentsCount { get; set; }

		[JsonProperty("MisfireChance")]
		public long MisfireChance { get; set; }

		[JsonProperty("PenetrationChance")]
		public long PenetrationChance { get; set; }

		[JsonProperty("PenetrationPowerDiviation")]
		public long PenetrationPowerDiviation { get; set; }

		[JsonProperty("ProjectileCount")]
		public long ProjectileCount { get; set; }

		[JsonProperty("RicochetChance")]
		public long RicochetChance { get; set; }

		[JsonProperty("ShowBullet")]
		public bool ShowBullet { get; set; }

		[JsonProperty("ShowHitEffectOnExplode")]
		public bool ShowHitEffectOnExplode { get; set; }

		[JsonProperty("SpeedRetardation")]
		public long SpeedRetardation { get; set; }

		[JsonProperty("StaminaBurnPerDamage")]
		public decimal StaminaBurnPerDamage { get; set; }

		[JsonProperty("TracerColor")]
		public string TracerColor { get; set; }

		[JsonProperty("TracerDistance")]
		public long TracerDistance { get; set; }

		[JsonProperty("ammoAccr")]
		public long AmmoAccr { get; set; }

		[JsonProperty("ammoDist")]
		public long AmmoDist { get; set; }

		[JsonProperty("ammoHear")]
		public long AmmoHear { get; set; }

		[JsonProperty("ammoRec")]
		public long AmmoRec { get; set; }

		[JsonProperty("ammoSfx")]
		public string AmmoSfx { get; set; }

		[JsonProperty("ammoShiftChance")]
		public long AmmoShiftChance { get; set; }

		[JsonProperty("ammoType")]
		public string AmmoType { get; set; }

		[JsonProperty("buckshotBullets")]
		public long BuckshotBullets { get; set; }

		[JsonProperty("casingEjectPower")]
		public long CasingEjectPower { get; set; }

		[JsonProperty("casingMass")]
		public long CasingMass { get; set; }

		[JsonProperty("casingName")]
		public string CasingName { get; set; }

		[JsonProperty("casingSounds")]
		public string CasingSounds { get; set; }
	}

	public class ArmorDistanceDistanceDamage
	{
		[JsonProperty("x")]
		public long X { get; set; }

		[JsonProperty("y")]
		public long Y { get; set; }

		[JsonProperty("z")]
		public long Z { get; set; }
	}
}
