using System;
using System.Collections.Generic;
using RatStash;

namespace RatStashTest;

public class TestEnvironment
{
	public string BasePath;

	public TestEnvironment()
	{
		BasePath = AppDomain.CurrentDomain.BaseDirectory;
	}

	/// <summary>
	/// Combine two paths
	/// </summary>
	/// <param name="basePath">Base path</param>
	/// <param name="x">Path to be added</param>
	/// <returns>The combined path</returns>
	public static string Combine(string basePath, string x)
	{
		return System.IO.Path.Combine(basePath, x);
	}

	public static int LevenshteinDistance(string target, string value)
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

	public Database GetDatabase(string locale = "en", bool cleaned = false)
	{
		var itemsPath = Combine(BasePath, "TestData\\items.json");
		var localePath = Combine(BasePath, $"TestData\\locales\\{locale}.json");
		return Database.FromFile(itemsPath, cleaned, localePath);
	}

	public Dictionary<int, (Item item, ItemExtraInfo itemExtraInfo)> GetCacheIndex(Database database)
	{
		var cacheIndexPath = Combine(BasePath, "TestData\\index.json");
		return database.ParseItemCacheIndex(cacheIndexPath);
	}

	public Dictionary<int, (Item item, ItemExtraInfo itemExtraInfo)> GetCacheHashIndex(Database database)
	{
		var cacheHashIndexPath = Combine(BasePath, "TestData\\hashIndex.json");
		return database.ParseItemCacheHashIndex(cacheHashIndexPath);
	}
}