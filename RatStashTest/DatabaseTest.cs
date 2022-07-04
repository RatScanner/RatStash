using System;
using System.Collections.Generic;
using System.Linq;
using DeepEqual.Syntax;
using RatStash;
using Xunit;

namespace RatStashTest;

public class DatabaseTest : TestEnvironment
{
	[Fact]
	public void LoadEnglishDatabase()
	{
		var database = GetDatabase();
		var item = database.GetItem("59e7635f86f7742cbf2c1095");
		Assert.Equal("BNTI Module-3M body armor", item.Name);
		Assert.Equal(22813, item.CreditsPrice);
	}

	[Fact]
	public void LoadGermanDatabase()
	{
		var database = GetDatabase("ge");
		var item = database.GetItem("59e7635f86f7742cbf2c1095");
		Assert.Equal("Modulare Schutzweste von 3M", item.Name);
		Assert.Equal(22813, item.CreditsPrice);
	}

	[Fact]
	public void LoadRussianDatabase()
	{
		var database = GetDatabase("ru");
		var item = database.GetItem("59e7635f86f7742cbf2c1095");
		Assert.Equal("Бронежилет БНТИ \"Модуль-3М\"", item.Name);
		Assert.Equal(22813, item.CreditsPrice);
	}

	[Fact]
	public void LoadAllLocalizedDatabases()
	{
		foreach (var locale in Enum.GetValues<Language>())
		{
			var database = GetDatabase(locale.ToBSGCode());
			var item = database.GetItem("59e7635f86f7742cbf2c1095");
			Assert.False(item.Name == "Module 3M");
		}
	}

	[Fact]
	public void QueryItemById()
	{
		var database = GetDatabase();
		var item = database.GetItem("5644bd2b4bdc2d3b4c8b4572");
		Assert.NotNull(item);
		Assert.Equal(typeof(AssaultRifle), item.GetType());
		var arItem = (AssaultRifle)item;
		var slots = arItem.Slots;
		Assert.Equal(10, slots.Count);
		Assert.Equal("mod_muzzle", slots[2].Name);
		Assert.NotEmpty(slots[2].Filters);
		Assert.Contains(slots[2].Filters[0].Whitelist, id => id == "5ac72e945acfc43f3b691116");
	}

	[Fact]
	public void QueryItemByDiscriminator()
	{
		var database = GetDatabase();
		var items = database.GetItems(item => item.ShortName == "MRE").ToArray();
		Assert.True(items.Any());
		var expected = database.GetItem("590c5f0d86f77413997acfab");
		var actual = items.First();
		Assert.True(expected.IsDeepEqual(actual));
	}

	[Fact]
	public void QueryMaxItem()
	{
		var database = GetDatabase();
		var mostValuableItem = database.GetItem(item => item.CreditsPrice);
		Assert.Equal("Secure container Kappa", mostValuableItem.Name);
	}

	[Fact]
	public void QueryByName()
	{
		var database = GetDatabase();
		var query = "A8H 12 p0Iymr";
		var result = database.GetItem(item => LevenshteinDistance(item.Name, query) * -1);
		Assert.StartsWith("ASh-12 polymer handguard", result.Name);
	}

	[Fact]
	public void QueryAllItems()
	{
		var database = GetDatabase();
		var items = database.GetItems().ToArray();
		Assert.Equal(2559, items.Length);
		Assert.DoesNotContain(null, items);
	}

	[Fact]
	public void CheckCleanDatabase()
	{
		var database = GetDatabase("en", true);
		var item = database.GetItem("59e6658b86f77411d949b250");
		Assert.Equal(".366 TKM Geksa", item.Name);  // "TKM" are latin chars
		Assert.Equal("Geksa", item.ShortName);
		Assert.StartsWith("A .366 TKM (9.55x39mm) Geksa cartridge with ", item.Description); // "TKM" are latin chars
	}

	[Fact]
	public void CheckUncleanDatabase()
	{
		return; // TODO
		var database = GetDatabase();
		var item = database.GetItem("59e6658b86f77411d949b250");
		Assert.Equal(".366 ТКМ Geksa", item.Name);  // "ТКМ" are cyrillic chars
		Assert.Equal("Geksa", item.ShortName);
		Assert.Equal(".366 ТКМ Geksa cartridge", item.Description); // "ТКМ" are cyrillic chars
	}

	[Fact]
	public void FilterDatabase()
	{
		var database = GetDatabase();
		var filteredDatabase = GetDatabase().Filter(item => !item.QuestItem);

		Assert.Equal(2559, database.GetItems().Count());
		Assert.Equal(2503, filteredDatabase.GetItems().Count());

		Assert.NotNull(database.GetItem("5939a00786f7742fe8132936"));
		Assert.Null(filteredDatabase.GetItem("5939a00786f7742fe8132936"));
		Assert.NotNull(database.GetItem("56742c2e4bdc2d95058b456d"));
		Assert.NotNull(filteredDatabase.GetItem("56742c2e4bdc2d95058b456d"));
	}

	[Fact]
	public void ParseItemCacheIndex()
	{
		var database = GetDatabase();
		var cacheIndex = GetCacheIndex(database);
		Assert.Equal(48, cacheIndex.Count);

		var item = cacheIndex[12].item;
		var itemExtraInfo = cacheIndex[12].itemExtraInfo;

		Assert.Equal("6B47", item.ShortName);
		Assert.True(item is CompoundItem);
		Assert.True(itemExtraInfo.ItemIsToggled);

		var slots = (item as CompoundItem).Slots;
		Assert.Equal(2, slots.Count);
		Assert.Equal("mod_nvg", slots[0].Name);
		Assert.Equal("GPNVG-18", slots[0].ContainedItem.ShortName);
	}

	[Fact]
	public void ParseItemCacheHashIndex()
	{
		var database = GetDatabase();
		var cacheIndex = GetCacheHashIndex(database);
		Assert.True(cacheIndex.Count >= 36);

		var item = cacheIndex[14].item;

		Assert.Equal("PVS-14", item.ShortName);
		Assert.True(item is CompoundItem);
	}
}