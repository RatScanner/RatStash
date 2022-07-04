using RatStash;
using Xunit;

namespace RatStashTest;

public class ItemExtraInfoTest
{
	[Fact]
	public void ValueEquals()
	{
		var extraInfo1 = new ItemExtraInfo()
		{
			MaxVisibleAmmo = 3,
			AmmoIsUsed = true,
			ItemIsToggled = false,
			WeaponIsFolded = true,
		};

		var extraInfo2 = new ItemExtraInfo()
		{
			MaxVisibleAmmo = 3,
			AmmoIsUsed = true,
			ItemIsToggled = false,
			WeaponIsFolded = true,
		};

		Assert.Equal(extraInfo1, extraInfo2);
		Assert.True(extraInfo1 == extraInfo2);

		extraInfo2.AmmoIsUsed = false;
		Assert.NotEqual(extraInfo1, extraInfo2);
		Assert.True(extraInfo1 != extraInfo2);
	}

	[Fact]
	public void ReferenceEqual()
	{
		var extraInfo = new ItemExtraInfo()
		{
			MaxVisibleAmmo = 3,
			AmmoIsUsed = true,
			ItemIsToggled = false,
			WeaponIsFolded = true,
		};

		Assert.Equal(extraInfo, extraInfo);
		Assert.True(extraInfo == extraInfo);
	}
}