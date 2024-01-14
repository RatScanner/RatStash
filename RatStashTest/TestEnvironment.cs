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

	public static float NormedLevenshteinDistance(string source, string target)
	{
		if (string.IsNullOrEmpty(source))
		{
			return string.IsNullOrEmpty(target) ? 0 : target.Length;
		}

		if (string.IsNullOrEmpty(target)) return source.Length;

		if (source.Length > target.Length)
		{
			var temp = target;
			target = source;
			source = temp;
		}

		var m = target.Length;
		var n = source.Length;
		var distance = new int[2, m + 1];
		// Initialize the distance matrix
		for (var j = 1; j <= m; j++) distance[0, j] = j;

		var currentRow = 0;
		for (var i = 1; i <= n; ++i)
		{
			currentRow = i & 1;
			distance[currentRow, 0] = i;
			var previousRow = currentRow ^ 1;
			for (var j = 1; j <= m; j++)
			{
				var cost = (target[j - 1] == source[i - 1] ? 0 : 1);
				distance[currentRow, j] = Math.Min(Math.Min(
						distance[previousRow, j] + 1,
						distance[currentRow, j - 1] + 1),
					distance[previousRow, j - 1] + cost);
			}
		}

		return (float)(target.Length - distance[currentRow, m]) / target.Length;
	}

	public Database GetDatabase(string locale = "en", bool cleaned = false)
	{
		var itemsPath = Combine(BasePath, "TestData\\items.json");
		var localePath = Combine(BasePath, $"TestData\\locales\\{locale}.json");
		return Database.FromFile(itemsPath, cleaned, localePath).Filter(i => i.Name != "" && i.ShortName != "");
	}
}
