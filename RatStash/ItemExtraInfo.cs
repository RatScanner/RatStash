using System;

namespace RatStash
{
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

		public static ItemExtraInfo operator +(ItemExtraInfo extraInfoL, ItemExtraInfo extraInfoR)
		{
			return new ItemExtraInfo
			{
				ItemIsToggled = extraInfoL.ItemIsToggled || extraInfoR.ItemIsToggled,
				AmmoIsUsed = extraInfoL.AmmoIsUsed || extraInfoR.AmmoIsUsed,
				WeaponIsFolded = extraInfoL.WeaponIsFolded || extraInfoR.WeaponIsFolded,
				MaxVisibleAmmo = Math.Max(extraInfoL.MaxVisibleAmmo, extraInfoR.MaxVisibleAmmo)
			};
		}
	}
}
