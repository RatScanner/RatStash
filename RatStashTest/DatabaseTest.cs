using System.Collections.Generic;
using System.Linq;
using DeepEqual.Syntax;
using RatStash;
using Xunit;

namespace RatStashTest
{
	public class DatabaseTest : TestEnvironment
	{
		[Fact]
		public void LoadDatabase()
		{
			GetDatabase();
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
			Assert.Equal("Mystery Ranch Terraplane Backpack", mostValuableItem.Name);
		}

		[Fact]
		public void QueryByName()
		{
			var database = GetDatabase();
			var query = "A8 Arms M0D X Gen 8";
			var result = database.GetItem(item => LevenshteinDistance(item.Name, query) * -1);
			Assert.Equal("A*B Arms MOD X Gen.3 keymod handguard for M700", result.Name);
		}

		[Fact]
		public void QueryAllItems()
		{
			var database = GetDatabase();
			var items = database.GetItems().ToArray();
			Assert.Equal(2245, items.Length);
			Assert.DoesNotContain(null, items);
		}

		[Fact]
		public void CheckCleanDatabase()
		{
			var database = GetDatabase();
			var item = database.GetItem("59e6658b86f77411d949b250");
			Assert.Equal(".366 TKM Geksa", item.Name);  // "TKM" are latin chars
			Assert.Equal("Geksa", item.ShortName);
			Assert.Equal(".366 TKM Geksa cartridge", item.Description); // "TKM" are latin chars
		}

		[Fact]
		public void CheckUncleanDatabase()
		{
			var database = GetDatabase(false);
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

			Assert.Equal(2245, database.GetItems().Count());
			Assert.Equal(2203, filteredDatabase.GetItems().Count());

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

		private static int LevenshteinDistance(string target, string value)
		{
			if (target.Length > value.Length) target = target.Substring(0, value.Length);

			if (target.Length == 0) return value.Length;
			if (value.Length == 0) return target.Length;

			var costs = new int[target.Length];

			// Add indexing for insertion to first row
			for (var i = 0; i < costs.Length;) costs[i] = ++i;

			for (var i = 0; i < value.Length; i++)
			{
				// Cost of the first index
				var cost = i;
				var additionCost = i;

				// Cache value for inner loop to avoid index lookup and bonds checking, profiled this is quicker
				var value2Char = value[i];

				for (var j = 0; j < target.Length; j++)
				{
					var insertionCost = cost;
					cost = additionCost;

					// Assigning this here reduces the array reads we do
					additionCost = costs[j];

					if (value2Char != target[j])
					{
						if (insertionCost < cost) cost = insertionCost;
						if (additionCost < cost) cost = additionCost;
						++cost;
					}

					costs[j] = cost;
				}
			}

			return costs[^1];
		}

		private Database GetDatabase(bool cleaned = true)
		{
			return Database.FromFile(Combine(BasePath, "TestData\\items.json"), cleaned);
		}

		private Dictionary<int, (Item item, ItemExtraInfo itemExtraInfo)> GetCacheIndex(Database database)
		{
			var cacheIndexPath = Combine(BasePath, "TestData\\index.json");
			return database.ParseItemCacheIndex(cacheIndexPath);
		}
	}
}
