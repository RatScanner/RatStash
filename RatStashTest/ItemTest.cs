using System.Collections.Generic;
using RatStash;
using Xunit;

namespace RatStashTest;

public class ItemTest : TestEnvironment
{
	[Fact]
	public void SizeComputation()
	{
		var database = GetDatabase();
		var item = database.GetItem("5c07c60e0db834002330051f");
		Assert.Equal((1, 1), item.GetSlotSize());

		if (item is AssaultRifle rifle)
		{
			var grip = database.GetItem("5c0e2ff6d174af02a1659d4a");
			rifle.Slots[0].ContainedItem = grip;

			var stock = database.GetItem("5a33ca0fc4a282000d72292f");
			rifle.Slots[3].ContainedItem = stock;
			Assert.Equal((2, 2), rifle.GetSlotSize());
		}
		else Assert.False(true);
	}

	[Fact]
	public void ValueEquals()
	{
		var item1 = new Weapon()
		{
			Id = "5c07c60e0db834002330051f",
			Name = "ADAR",
		};

		var item2 = new Weapon()
		{
			Id = "5c07c60e0db834002330051f",
			Name = "Other Weapon but same Id",
		};

		Assert.Equal(item1, item2);
		Assert.True(item1 == item2);

		item2.Id = "5c07c60e0db834002330051f-different";
		Assert.NotEqual(item1, item2);
		Assert.True(item1 != item2);
	}

	[Fact]
	public void ValueEqualsSlots()
	{

		var item1 = new Weapon()
		{
			Id = "5c07c60e0db834002330051f",
			Name = "ADAR",
			Slots = new List<Slot>()
			{
				new Slot()
				{
					ContainedItem = new CompactCollimator()
					{
						Id = "57ae0171245977343c27bfcf",
						Name = "PK-06",
					}
				}
			}
		};

		var item2 = new Weapon()
		{
			Id = "5c07c60e0db834002330051f",
			Name = "Other weapon but same id",
			Slots = new List<Slot>()
			{
				new Slot()
				{
					ContainedItem = new CompactCollimator()
					{
						Id = "57ae0171245977343c27bfcf",
						Name = "Other sight but same id",
					}
				}
			}
		};

		Assert.Equal(item1, item2);
		Assert.True(item1 == item2);

		item2.Slots[0].ContainedItem.Id = "57ae0171245977343c27bfcf-different";
		Assert.NotEqual(item1, item2);
		Assert.True(item1 != item2);
	}

	[Fact]
	public void ReferenceEqual()
	{
		var item = new Weapon()
		{
			Id = "5c07c60e0db834002330051f",
			Name = "ADAR",
		};

		Assert.Equal(item, item);
		Assert.True(item == item);
	}

	[Fact]
	public void WeaponTest()
	{
		var database = GetDatabase();
		var item = database.GetItem("5ac4cd105acfc40016339859");
		Assert.False(item.Equals(null));
		Assert.True(item.Equals(item));
		Assert.NotEqual(item.GetSlotSize(), (0, 0));
		Assert.NotNull(item.GetType());
		Assert.NotNull(item.ToString());
	}
}
