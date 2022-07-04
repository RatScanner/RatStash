using System;

namespace RatStash;

public class ItemExtraInfo
{
	/// <summary>
	/// Indicates that ammo was already shot
	/// </summary>
	public bool AmmoIsUsed;

	/// <summary>
	/// Items which have hinges like helmets with face covers can be toggled
	/// </summary>
	/// <remarks>
	/// Enabling tactical devices is not considered toggling.
	/// Folded weapons are also not considered toggled but instead <see cref="WeaponIsFolded"/>.
	/// </remarks>
	public bool ItemIsToggled;

	/// <summary>
	/// Indicates that a weapon is folded
	/// </summary>
	/// <remarks>
	/// For other items like helmets with face covers see <see cref="ItemIsToggled"/>
	/// </remarks>
	public bool WeaponIsFolded;

	/// <summary>
	/// The amount of ammunition visible when looking at a magazine from the outside
	/// </summary>
	public int MaxVisibleAmmo;

	/// <summary>
	/// Combine two item extra info objects into one
	/// </summary>
	/// <param name="extraInfoL">First object</param>
	/// <param name="extraInfoR">Second object</param>
	/// <returns>Combined object</returns>
	public static ItemExtraInfo operator +(ItemExtraInfo extraInfoL, ItemExtraInfo extraInfoR)
	{
		return new()
		{
			ItemIsToggled = extraInfoL.ItemIsToggled || extraInfoR.ItemIsToggled,
			AmmoIsUsed = extraInfoL.AmmoIsUsed || extraInfoR.AmmoIsUsed,
			WeaponIsFolded = extraInfoL.WeaponIsFolded || extraInfoR.WeaponIsFolded,
			MaxVisibleAmmo = Math.Max(extraInfoL.MaxVisibleAmmo, extraInfoR.MaxVisibleAmmo)
		};
	}

	public override bool Equals(object obj)
	{
		if ((obj == null) || GetType() != obj.GetType()) return false;

		var extraInfo = (ItemExtraInfo)obj;

		if (ItemIsToggled != extraInfo.ItemIsToggled) return false;
		if (AmmoIsUsed != extraInfo.AmmoIsUsed) return false;
		if (WeaponIsFolded != extraInfo.WeaponIsFolded) return false;
		if (MaxVisibleAmmo != extraInfo.MaxVisibleAmmo) return false;
		return true;
	}

	public override int GetHashCode()
	{
		var hashCode = 0;
		hashCode += ItemIsToggled ? (1 << 0) : 0;
		hashCode += AmmoIsUsed ? (1 << 1) : 0;
		hashCode += WeaponIsFolded ? (1 << 2) : 0;
		hashCode += MaxVisibleAmmo << 3;
		return hashCode;
	}

	public static bool operator ==(ItemExtraInfo lhs, ItemExtraInfo rhs)
	{
		if (ReferenceEquals(lhs, rhs)) return true;
		if (ReferenceEquals(lhs, null)) return false;
		if (ReferenceEquals(rhs, null)) return false;

		return lhs.Equals(rhs);
	}

	public static bool operator !=(ItemExtraInfo lhs, ItemExtraInfo rhs) => !(lhs == rhs);
}