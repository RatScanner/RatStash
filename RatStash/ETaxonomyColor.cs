using System.Collections.Generic;
using System.Drawing;

namespace RatStash
{
	public enum TaxonomyColor
	{
		Default,
		Blue,
		Yellow,
		Green,
		Red,
		Black,
		Grey,
		Violet,
		Orange,
		TracerYellow,
		TracerGreen,
		TracerRed,
	}

	internal static class TaxonomyColorConverter
	{
		private static readonly Dictionary<TaxonomyColor, Color> _colorDict = new Dictionary<TaxonomyColor, Color>()
		{

			{
				TaxonomyColor.Default,
				Color.FromArgb(127, 127, 127)
			},
			{
				TaxonomyColor.Blue,
				Color.FromArgb(28, 65, 86)
			},
			{
				TaxonomyColor.Yellow,
				Color.FromArgb(104, 102, 40)
			},
			{
				TaxonomyColor.Green,
				Color.FromArgb(21, 45, 0)
			},
			{
				TaxonomyColor.Red,
				Color.FromArgb(109, 36, 24)
			},
			{
				TaxonomyColor.TracerYellow,
				Color.FromArgb(510, 334, 146)
			},
			{
				TaxonomyColor.TracerGreen,
				Color.FromArgb(117, 383, 129)
			},
			{
				TaxonomyColor.TracerRed,
				Color.FromArgb(510, 60, 60)
			},
			{
				TaxonomyColor.Black,
				Color.FromArgb(0, 0, 0)
			},
			{
				TaxonomyColor.Grey,
				Color.FromArgb(29, 29, 29)
			},
			{
				TaxonomyColor.Violet,
				Color.FromArgb(76, 42, 85)
			},
			{
				TaxonomyColor.Orange,
				Color.FromArgb(60, 25, 0)
			},
		};

		public static Color ToColor(this TaxonomyColor taxonomyColor)
		{
			return _colorDict[taxonomyColor];
		}
	}
}
