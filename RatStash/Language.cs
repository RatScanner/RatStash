using System;

namespace RatStash;

public enum Language
{
	Chinese,
	Czech,
	English,
	Spanish,
	SpanishMexican,
	French,
	German,
	Hungarian,
	Italian,
	Japanese,
	Korean,
	Polish,
	Portuguese,
	Russian,
	Slovak,
	Turkish,
	Romanian,
}

public static class LanguageConverter
{
	/// <summary>
	/// Convert the language to the code BSG uses to identify the language.
	/// This is in most cases the first two characters of the language name in english.
	/// There are exceptions to everything with BSG though.
	/// </summary>
	/// <param name="language">The language to convert</param>
	/// <returns>Code used by BSG to identify the language</returns>
	public static string ToBSGCode(this Language language)
	{
		return language switch
		{
			Language.Chinese => "ch",
			Language.Czech => "cz",
			Language.English => "en",
			Language.Spanish => "es",
			Language.SpanishMexican => "es-mx",
			Language.French => "fr",
			Language.German => "ge",
			Language.Hungarian => "hu",
			Language.Italian => "it",
			Language.Japanese => "jp",
			Language.Korean => "kr",
			Language.Polish => "pl",
			Language.Portuguese => "po",
			Language.Russian => "ru",
			Language.Slovak => "sk",
			Language.Turkish => "tu",
			Language.Romanian => "ro",
		};
	}

	/// <summary>
	/// Convert the language to its ISO 639-3 code
	/// </summary>
	/// <param name="language">The language to convert</param>
	/// <returns>ISO 639-3 code</returns>
	public static string ToISO3Code(this Language language)
	{
		return language switch
		{
			Language.Chinese => "zho",
			Language.Czech => "ces",
			Language.English => "eng",
			Language.Spanish => "spa",
			Language.SpanishMexican => "spa",
			Language.French => "fra",
			Language.German => "deu",
			Language.Hungarian => "hun",
			Language.Italian => "ita",
			Language.Japanese => "jpn",
			Language.Korean => "kor",
			Language.Polish => "pol",
			Language.Portuguese => "por",
			Language.Russian => "rus",
			Language.Slovak => "slk",
			Language.Turkish => "tur",
			Language.Romanian => "rou",
		};
	}
}
