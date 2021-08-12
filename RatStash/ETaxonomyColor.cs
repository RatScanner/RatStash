using System.Collections.Generic;

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

	public static class TaxonomyColorConverter
	{
		private static readonly Dictionary<TaxonomyColor, Color> ColorDict = new()
		{
			{
				TaxonomyColor.Default,
				new Color(127, 127, 127)
			},
			{
				TaxonomyColor.Blue,
				new Color(28, 65, 86)
			},
			{
				TaxonomyColor.Yellow,
				new Color(104, 102, 40)
			},
			{
				TaxonomyColor.Green,
				new Color(21, 45, 0)
			},
			{
				TaxonomyColor.Red,
				new Color(109, 36, 24)
			},
			{
				TaxonomyColor.TracerYellow,
				new Color(510, 334, 146)
			},
			{
				TaxonomyColor.TracerGreen,
				new Color(117, 383, 129)
			},
			{
				TaxonomyColor.TracerRed,
				new Color(510, 60, 60)
			},
			{
				TaxonomyColor.Black,
				new Color(0, 0, 0)
			},
			{
				TaxonomyColor.Grey,
				new Color(29, 29, 29)
			},
			{
				TaxonomyColor.Violet,
				new Color(76, 42, 85)
			},
			{
				TaxonomyColor.Orange,
				new Color(60, 25, 0)
			},
		};

		public static Color ToColor(this TaxonomyColor taxonomyColor)
		{
			return ColorDict[taxonomyColor];
		}
	}
}
