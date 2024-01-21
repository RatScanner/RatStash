using System.Collections.Generic;
using RatStash;
using Xunit;
using System.Linq;

namespace RatStashTest;

public class ArmorTest : TestEnvironment
{
	[Fact]
	public void TestGettingArmorArmorRigPlateInserts()
	{
		var database = GetDatabase();
		var armor = database.GetItem("545cdb794bdc2d3a198b456a");
		var armorRig = database.GetItem("61bcc89aef0f505f0c6cd0fc");
		var plate = database.GetItem("6575ce3716c2762fba0057fd");
		var insert = database.GetItem("6570f71dd67d0309980a7af8");

		var BuiltIns = database.GetItems(x => x is BuiltInInserts).ToList();

		Assert.NotNull(armor);
		Assert.NotNull(armorRig);
		Assert.NotNull(plate);
		Assert.NotNull(insert);
		Assert.True(BuiltIns.Count > 0);
	}

	[Fact]
	public void TestAssembleArmor()
	{
		var database = GetDatabase();
		Armor item = (Armor)database.GetItem("545cdb794bdc2d3a198b456a");
		foreach (var slot in item.Slots)
		{
			var plate = database.GetItem(slot.Filters[0].PlateId);
			slot.ContainedItem = plate;
		}
		Assert.NotNull(item);

		foreach (var slot in item.Slots)
		{
			Assert.NotNull(slot.ContainedItem);
		}
	}

	[Fact]
	public void TestGetArmorCollidersArmor()
	{
		var database = GetDatabase();
		Armor item = (Armor)database.GetItem("545cdb794bdc2d3a198b456a");
		var colliders = item.GetArmorColliders();
		var plateColliders = item.GetArmorPlateColliders();
		Assert.True(colliders.Count > 0);
		Assert.True(plateColliders.Count > 0);
	}
	[Fact]
	public void TestGetArmorCollidersRig()
	{
		var database = GetDatabase();
		ChestRig item = (ChestRig)database.GetItem("61bcc89aef0f505f0c6cd0fc");
		var colliders = item.GetArmorColliders();
		var plateColliders = item.GetArmorPlateColliders();
		Assert.True(colliders.Count > 0);
		Assert.True(plateColliders.Count > 0);
	}
}
