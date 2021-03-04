using System;

namespace RatStashTest
{
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
		internal static string Combine(string basePath, string x)
		{
			return System.IO.Path.Combine(basePath, x);
		}
	}
}
