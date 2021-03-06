﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace RatStash
{
	public class ItemFilter
	{
		[JsonProperty("Filter")]
		public List<string> Whitelist { get; set; } = new List<string>();

		[JsonProperty("ExcludedFilter")]
		public List<string> Blacklist { get; set; } = new List<string>();
	}
}
