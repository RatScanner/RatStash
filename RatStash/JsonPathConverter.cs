using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RatStash
{
	internal class JsonPathConverter : JsonConverter
	{
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
			JsonSerializer serializer)
		{
			var jo = JObject.Load(reader);
			var targetObj = Activator.CreateInstance(objectType);

			var props = objectType.GetProperties().Where(p => p.CanRead && p.CanWrite);

			foreach (var prop in props)
			{
				var att = prop.GetCustomAttributes(true)
					.OfType<JsonPropertyAttribute>()
					.FirstOrDefault();

				var jsonPath = (att != null ? att.PropertyName : prop.Name);
				var token = jo.SelectToken(jsonPath);

				if (token != null && token.Type != JTokenType.Null)
				{
					var value = token.ToObject(prop.PropertyType, serializer);
					prop.SetValue(targetObj, value, null);
				}
			}

			return targetObj;
		}

		public override bool CanConvert(Type objectType)
		{
			// CanConvert is not called when [JsonConverter] attribute is used
			return false;
		}

		public override bool CanWrite => false;

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}
}
