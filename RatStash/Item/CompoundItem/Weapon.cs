namespace RatStash
{
	using Newtonsoft.Json;

	public class Weapon
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
        public Slot[] Chambers { get; set; }

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
        public string FoldedSlot { get; set; }

        [JsonProperty("HipAccuracyRestorationDelay")]
        public float HipAccuracyRestorationDelay { get; set; }

        [JsonProperty("HipAccuracyRestorationSpeed")]
        public float HipAccuracyRestorationSpeed { get; set; }

        [JsonProperty("HipInnaccuracyGain")]
        public float HipInnaccuracyGain { get; set; }

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

        [JsonProperty("MustBoltBeOpennedForExternalReload")]
        public bool MustBoltBeOpennedForExternalReload { get; set; }

        [JsonProperty("MustBoltBeOpennedForInternalReload")]
        public bool MustBoltBeOpennedForInternalReload { get; set; }

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
        public int RecolDispersion { get; set; }

        [JsonProperty("ReloadMode")]
        public string ReloadMode { get; set; }

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
        public decimal TacticalReloadFixation { get; set; }

        [JsonProperty("TacticalReloadStiffnes")]
        public Vector3 TacticalReloadStiffnes { get; set; }

        [JsonProperty("Velocity")]
        public float Velocity { get; set; }

        [JsonProperty("ammoCaliber")]
        public string AmmoCaliber { get; set; }

        [JsonProperty("bEffDist")]
        public int BEffDist { get; set; }

        [JsonProperty("bFirerate")]
        public int BFirerate { get; set; }

        [JsonProperty("bHearDist")]
        public int BHearDist { get; set; }

        [JsonProperty("chamberAmmoCount")]
        public int ChamberAmmoCount { get; set; }

        [JsonProperty("defAmmo")]
        public string DefAmmo { get; set; }

        [JsonProperty("defMagType")]
        public string DefMagType { get; set; }

        [JsonProperty("durabSpawnMax")]
        public int DurabSpawnMax { get; set; }

        [JsonProperty("durabSpawnMin")]
        public int DurabSpawnMin { get; set; }

        [JsonProperty("isBoltCatch")]
        public bool IsBoltCatch { get; set; }

        [JsonProperty("isChamberLoad")]
        public bool IsChamberLoad { get; set; }

        [JsonProperty("isFastReload")]
        public bool IsFastReload { get; set; }

        [JsonProperty("shotgunDispersion")]
        public int ShotgunDispersion { get; set; }

        [JsonProperty("weapClass")]
        public string WeapClass { get; set; }

        [JsonProperty("weapFireType")]
        public object[] WeapFireType { get; set; }

        [JsonProperty("weapUseType")]
        public string WeapUseType { get; set; }
    }
}
