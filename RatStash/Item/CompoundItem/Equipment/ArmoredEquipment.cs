namespace RatStash
{
	using Newtonsoft.Json;

	public class ArmoredEquipment : Equipment
	{
		[JsonProperty("ArmorMaterial")]
		public string ArmorMaterial { get; set; }

		[JsonProperty("BlindnessProtection")]
		public int BlindnessProtection { get; set; }

		[JsonProperty("BluntThroughput")]
		public int BluntThroughput { get; set; }

		[JsonProperty("DeafStrength")]
		public string DeafStrength { get; set; }

		[JsonProperty("Durability")]
		public int Durability { get; set; }

		[JsonProperty("FaceShieldComponent")]
		public bool FaceShieldComponent { get; set; }

		[JsonProperty("FaceShieldMask")]
		public string FaceShieldMask { get; set; }

		[JsonProperty("HasHinge")]
		public bool HasHinge { get; set; }

		[JsonProperty("Indestructibility")]
		public decimal Indestructibility { get; set; }

		[JsonProperty("MaterialType")]
		public string MaterialType { get; set; }

		[JsonProperty("MaxDurability")]
		public int MaxDurability { get; set; }

		[JsonProperty("RicochetParams")]
		public RicochetParams RicochetParams { get; set; }

		[JsonProperty("armorClass")]
		public int ArmorClass { get; set; }

		[JsonProperty("armorZone")]
		public object[] ArmorZone { get; set; }

		[JsonProperty("headSegments")]
		public object[] HeadSegments { get; set; }

		[JsonProperty("mousePenalty")]
		public int MousePenalty { get; set; }

		[JsonProperty("speedPenaltyPercent")]
		public int SpeedPenaltyPercent { get; set; }

		[JsonProperty("weaponErgonomicPenalty")]
		public int WeaponErgonomicPenalty { get; set; }
	}

	public class RicochetParams
	{
		[JsonProperty("x")]
		public int X { get; set; }

		[JsonProperty("y")]
		public int Y { get; set; }

		[JsonProperty("z")]
		public int Z { get; set; }
	}
}
