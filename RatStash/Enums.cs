using System.Runtime.Serialization;

namespace RatStash;

public enum Location
{
	Bigmap,
	Interchange,
	Laboratory,
	RezervBase,
	Shoreline,
	Woods,
	Lighthouse,

	[EnumMember(Value = "factory4_day")]
	FactoryDay,

	[EnumMember(Value = "factory4_night")]
	FactoryNight
}

public enum AmmoType
{
	Buckshot,
	Bullet,
	Grenade,
	PropelledGrenade
}

public enum ArmorMaterial
{
	Aluminium,
	Aramid,
	ArmoredSteel,
	Ceramic,
	Combined,
	Glass,
	Titan,
	UHMWPE
}

public enum ArmorType
{
	None,
	Light,
	Heavy,
}

public enum ArmorZone
{
	Chest,
	Head,
	LeftArm,
	LeftLeg,
	RightArm,
	RightLeg,
	Stomach
}

public enum DeafStrength
{
	High,
	Low,
	None
}

public enum ExplosionType
{
	[EnumMember(Value = "")] Empty,

	[EnumMember(Value = "big_round_impact")]
	BigRoundImpact,

	[EnumMember(Value = "big_round_impact_explosive")]
	BigRoundImpactExplosive,

	[EnumMember(Value = "smallgrenade_expl")]
	SmallGrenadeExplosive
}

public enum FaceShieldMask
{
	Narrow,
	NoMask,
	Wide
}

public enum EffectType
{
	AfterUse,
	DuringUse
}

public enum HeadSegment
{
	Ears,
	Eyes,
	Jaws,
	Nape,
	LowerNape,
	Top
}

public enum MaterialType
{
	BodyArmor,
	GlassVisor,
	Helmet
}

public enum MuzzleModType
{
	Brake,
	Conpensator,
	MuzzleCombo,
	Pms,
	Silencer
}

public enum Rarity
{
	Common,
	[EnumMember(Value = "Not_exist")] NotExist,
	Rare,
	Superrare
}

public enum ItemDropSoundType
{
	None,
	Pistol,
	SubMachineGun,
	Rifle
}

public enum ReloadMode
{
	ExternalMagazine,
	InternalMagazine,
	OnlyBarrel,
	ExternalMagazineWithInternalReloadSupport
}

public enum SightModType
{
	Hybrid,
	Iron,
	Optic,
	Reflex,
	Holo
}

public enum Mask
{
	Thermal,
	Anvis,
	Binocular,
	GasMask,
	OldMonocular
}

public enum SelectablePalette
{
	Fusion,
	Rainbow,
	WhiteHot,
	BlackHot
}

public enum FactionSide
{
	Bear,
	Savage,
	Usec
}

public enum EquipmentSlot
{
	FirstPrimaryWeapon,
	SecondPrimaryWeapon,
	Holster,
	Scabbard,
	Backpack,
	SecuredContainer,
	TacticalVest,
	ArmorVest,
	Pockets,
	Eyewear,
	FaceCover,
	Headwear,
	Earpiece,
	Dogtag,
	ArmBand,
	Compass,
	SpecialSlot
}

public enum FireMode : byte
{
	Fullauto = 0,
	Single = 1,
	Doublet = 2,
	Burst = 3,
	Doubleaction = 4,
	Semiauto = 5
}

public enum RepairStrategy
{
	MeleeWeapon,
	Firearms,
	Armor,
}

public enum UseType
{
	Primary,
	Secondary
}

public enum Currency
{
	RUB,
	EUR,
	USD
}
