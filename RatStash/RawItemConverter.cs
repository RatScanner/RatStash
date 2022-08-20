using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using RatStash;

public class RawItemConverter<T> : JsonConverter
{

	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
	{
		throw new NotImplementedException("Not implemented yet");
	}

	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	{
		var array = JToken.Load(reader);
		var values = array.ToObject<List<RawItem<T>>>(serializer);
		return values.Select(y => y.Props).ToList();
	}

	public override bool CanWrite => false;

	public override bool CanConvert(Type objectType) => false;
}
