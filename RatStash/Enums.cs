namespace RatStash
{
	public enum Location { Bigmap, Interchange, Laboratory, RezervBase, Shoreline, Woods }

	public enum AmmoType { Buckshot, Bullet, Grenade, PropelledGrenade }

	public enum ArmorMaterial { Aluminium, Aramid, ArmoredSteel, Ceramic, Combined, Glass, Titan, UHMWPE }

	public enum ArmorZone { Chest, Head, LeftArm, LeftLeg, RightArm, RightLeg, Stomach }

	public enum DeafStrength { High, Low, None }

	public enum ExplosionType { BigRoundImpact, BigRoundImpactExplosive, Empty, SmallgrenadeExpl }

	public enum FaceShieldMask { Narrow, NoMask, Wide }

	public enum EffectType { AfterUse, DuringUse }

	public enum HeadSegment { Ears, Eyes, Jaws, Nape, Top }

	public enum MaterialType { BodyArmor, GlassVisor, Helmet }

	public enum MuzzleModType { Brake, Conpensator, MuzzleCombo, Pms, Silencer }

	public enum Rarity { Common, NotExist, Rare, Superrare }

	public enum ReloadMode { ExternalMagazine, InternalMagazine, OnlyBarrel }

	public enum SightModType { Hybrid, Iron, Optic, Reflex }

	public enum FactionSide { Bear, Savage, Usec }

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
	}

	public enum FireMode : byte
	{
		Fullauto = 0,
		Single = 1,
		Doublet = 2,
		Burst = 3
	}

	public enum UseType { Primary, Secondary }
}
