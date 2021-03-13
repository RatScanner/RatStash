using System;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RatStashTest")]

namespace RatStash
{
	internal static class Extensions
	{
		/// <summary>
		/// Split a string into left and right part
		/// </summary>
		/// <param name="str">String to split</param>
		/// <param name="separator">Character to split at</param>
		/// <param name="reverse">Search for the separator from right to left when set <see langword="true" /></param>
		/// <returns>String left and right from the first occurrence of the separator</returns>
		internal static (string left, string right) Split(this string str, string separator, bool reverse = false)
		{
			if (reverse)
			{
				var reversedStr = str.Reverse();
				var (left, right) = reversedStr.Split(separator.Reverse());
				return (right.Reverse(), left.Reverse());
			}
			else
			{
				var split = str.Split(new[] { separator }, 2, StringSplitOptions.None);
				return (split[0], split[1]);
			}
		}

		/// <summary>
		/// Reverse the string
		/// </summary>
		/// <param name="str">String to reverse</param>
		/// <returns>The reversed string</returns>
		internal static string Reverse(this string str)
		{
			return new string(str.ToCharArray().Reverse().ToArray());
		}
	}
}
