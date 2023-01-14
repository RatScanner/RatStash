using System.Collections.Generic;
using Newtonsoft.Json.Converters;

namespace RatStash;

public class Weapon : CompoundItem
{
	[JsonProperty("AimPlane")]
	public float AimPlane { get; set; }

	[JsonProperty("BoltAction")]
	public bool BoltAction { get; set; }

	[JsonProperty("CameraRecoil")]
	public float CameraRecoil { get; set; }

	[JsonProperty("CameraSnap")]
	public float CameraSnap { get; set; }

	[JsonProperty("CenterOfImpact")]
	public float CenterOfImpact { get; set; }

	[JsonProperty("Chambers")]
	public List<Slot> Chambers { get; set; } = new();

	[JsonProperty("CompactHandling")]
	public bool CompactHandling { get; set; }

	[JsonProperty("Convergence")]
	public float Convergence { get; set; }

	[JsonProperty("DeviationCurve")]
	public int DeviationCurve { get; set; }

	[JsonProperty("DeviationMax")]
	public int DeviationMax { get; set; }

	[JsonProperty("Durability")]
	public int Durability { get; set; }

	[JsonProperty("Ergonomics")]
	public int Ergonomics { get; set; }

	[JsonProperty("Foldable")]
	public bool Foldable { get; set; }

	[JsonProperty("FoldedSlot")]
	public string FoldedSlot { get; set; } = "";

	[JsonProperty("HipAccuracyRestorationDelay")]
	public float HipAccuracyRestorationDelay { get; set; }

	[JsonProperty("HipAccuracyRestorationSpeed")]
	public float HipAccuracyRestorationSpeed { get; set; }

	[JsonProperty("HipInnaccuracyGain")]
	public float HipInaccuracyGain { get; set; }

	[JsonProperty("IronSightRange")]
	public int IronSightRange { get; set; }

	[JsonProperty("ManualBoltCatch")]
	public bool ManualBoltCatch { get; set; }

	[JsonProperty("MaxDurability")]
	public int MaxDurability { get; set; }

	[JsonProperty("MaxRepairDegradation")]
	public float MaxRepairDegradation { get; set; }

	[JsonProperty("MinRepairDegradation")]
	public float MinRepairDegradation { get; set; }

	[JsonProperty("MinRepairKitDegradation")]
	public float MinRepairKitDegradation { get; set; }

	[JsonProperty("MaxRepairKitDegradation")]
	public float MaxRepairKitDegradation { get; set; }

	[JsonProperty("MustBoltBeOpennedForExternalReload")]
	public bool MustBoltBeOpenedForExternalReload { get; set; }

	[JsonProperty("MustBoltBeOpennedForInternalReload")]
	public bool MustBoltBeOpenedForInternalReload { get; set; }

	[JsonProperty("OperatingResource")]
	public int OperatingResource { get; set; }

	[JsonProperty("RecoilAngle")]
	public int RecoilAngle { get; set; }

	[JsonProperty("RecoilCenter")]
	public Vector3 RecoilCenter { get; set; }

	[JsonProperty("RecoilForceBack")]
	public int RecoilForceBack { get; set; }

	[JsonProperty("RecoilForceUp")]
	public int RecoilForceUp { get; set; }

	[JsonProperty("RecolDispersion")]
	public int RecoilDispersion { get; set; }

	[JsonProperty("ReloadMode")]
	[JsonConverter(typeof(StringEnumConverter))]
	public ReloadMode ReloadMode { get; set; }

	[JsonProperty("RepairComplexity")]
	public int RepairComplexity { get; set; }

	[JsonProperty("Retractable")]
	public bool Retractable { get; set; }

	[JsonProperty("RotationCenter")]
	public Vector3 RotationCenter { get; set; }

	[JsonProperty("RotationCenterNoStock")]
	public Vector3 RotationCenterNoStock { get; set; }

	[JsonProperty("SightingRange")]
	public int SightingRange { get; set; }

	[JsonProperty("SizeReduceRight")]
	public int SizeReduceRight { get; set; }

	[JsonProperty("TacticalReloadFixation")]
	public float TacticalReloadFixation { get; set; }

	[JsonProperty("TacticalReloadStiffnes")]
	public Vector3 TacticalReloadStiffness { get; set; }

	[JsonProperty("Velocity")]
	public float Velocity { get; set; }

	[JsonProperty("ammoCaliber")]
	public string AmmoCaliber { get; set; } = "";

	[JsonProperty("AdjustCollimatorsToTrajectory")]
	public bool AdjustCollimatorsToTrajectory { get; set; }

	[JsonProperty("bEffDist")]
	public int BEffectiveDistance { get; set; }

	[JsonProperty("bFirerate")]
	public int BFirerate { get; set; }

	[JsonProperty("SingleFireRate")]
	public int SingleFireRate { get; set; } = 240;

	[JsonProperty("CanQueueSecondShot")]
	public bool CanQueueSecondShot { get; set; } = true;

	[JsonProperty("bHearDist")]
	public int BHearDistance { get; set; }

	[JsonProperty("chamberAmmoCount")]
	public int ChamberAmmoCount { get; set; }

	[JsonProperty("defAmmo")]
	public string DefAmmo { get; set; } = "";

	[JsonProperty("defMagType")]
	public string DefMagType { get; set; } = "";

	[JsonProperty("durabSpawnMax")]
	public int DurabilitySpawnMax { get; set; }

	[JsonProperty("durabSpawnMin")]
	public int DurabilitySpawnMin { get; set; }

	[JsonProperty("isBoltCatch")]
	public bool IsBoltCatch { get; set; }

	[JsonProperty("isChamberLoad")]
	public bool IsChamberLoad { get; set; }

	[JsonProperty("isFastReload")]
	public bool IsFastReload { get; set; }

	[JsonProperty("shotgunDispersion")]
	public int ShotgunDispersionInt { get; set; }

	[JsonProperty("weapClass")]
	public string WeaponClass { get; set; } = "";

	[JsonProperty("AimSensitivity")]
	public float AimSensitivity { get; set; } = 1f;

	[JsonProperty("BurstShotsCount")]
	public int BurstShotsCount { get; set; } = 3;

	[JsonProperty("BaseMalfunctionChance")]
	public float BaseMalfunctionChance { get; set; }

	[JsonProperty("AllowJam")]
	public bool AllowJam { get; set; }

	[JsonProperty("AllowFeed")]
	public bool AllowFeed { get; set; }

	[JsonProperty("AllowMisfire")]
	public bool AllowMisfire { get; set; }

	[JsonProperty("AllowSlide")]
	public bool AllowSlide { get; set; }

	[JsonProperty("DurabilityBurnRatio")]
	public float DurabilityBurnRatio { get; set; } = 1f;

	[JsonProperty("HeatFactorGun")]
	public float HeatFactorGun { get; set; }

	[JsonProperty("CoolFactorGun")]
	public float CoolFactorGun { get; set; }

	[JsonProperty("AllowOverheat")]
	public bool AllowOverheat { get; set; }

	[JsonProperty("NoFiremodeOnBoltcatch")]
	public bool NoFiremodeOnBoltcatch { get; set; }

	[JsonProperty("HeatFactorByShot")]
	public float HeatFactorByShot { get; set; } = 1f;

	[JsonProperty("CoolFactorGunMods")]
	public float CoolFactorGunMods { get; set; } = 1f;

	[JsonProperty("RecoilPosZMult")]
	public float RecoilPosZMult { get; set; } = 1f;

	[JsonProperty("IsFlareGun")]
	public bool IsFlareGun { get; set; }

	[JsonProperty("IsOneoff")]
	public bool IsOneoff { get; set; }

	[JsonProperty("IsGrenadeLauncher")]
	public bool IsGrenadeLauncher { get; set; }

	[JsonProperty("DoubleActionAccuracyPenalty")]
	public float DoubleActionAccuracyPenalty { get; set; }

	[JsonProperty("weapFireType", ItemConverterType = typeof(StringEnumConverter))]
	public List<FireMode> WeaponFireType { get; set; } = new();

	[JsonProperty("weapUseType")]
	[JsonConverter(typeof(StringEnumConverter))]
	public UseType WeaponUseType { get; set; }
}
