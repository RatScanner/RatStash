using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RatStash
{
	internal class JsonPathConverter : JsonConverter
	{
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var jo = JObject.Load(reader);
			var targetObj = existingValue ?? Activator.CreateInstance(objectType);

			foreach (var prop in objectType.GetProperties().Where(p => p.CanRead))
			{
				var pathAttribute = prop.GetCustomAttributes(true).OfType<JsonPropertyAttribute>().FirstOrDefault();
				var converterAttribute = prop.GetCustomAttributes(true).OfType<JsonConverterAttribute>().FirstOrDefault();

				var jsonPath = pathAttribute?.PropertyName ?? prop.Name;
				var token = jo.SelectToken(jsonPath);

				if (token == null || token.Type == JTokenType.Null) continue;
				var done = false;

				if (converterAttribute != null)
				{
					var args = converterAttribute.ConverterParameters ?? Array.Empty<object>();
					var converter = Activator.CreateInstance(converterAttribute.ConverterType, args) as JsonConverter;
					if (converter != null && converter.CanRead)
					{
						using var sr = new StringReader(token.ToString());
						using var jr = new JsonTextReader(sr);
						var value = converter.ReadJson(jr, prop.PropertyType, prop.GetValue(targetObj),
							serializer);
						if (prop.CanWrite)
						{
							prop.SetValue(targetObj, value);
						}

						done = true;
					}
				}

				if (done) continue;

				if (prop.CanWrite)
				{
					var value = token.ToObject(prop.PropertyType, serializer);
					prop.SetValue(targetObj, value);
				}
				else
				{
					using var sr = new StringReader(token.ToString());
					serializer.Populate(sr, prop.GetValue(targetObj));
				}
			}

			return targetObj;
		}

		/// <remarks>
		/// CanConvert is not called when <see cref="JsonConverterAttribute">JsonConverterAttribute</see> is used.
		/// </remarks>
		public override bool CanConvert(Type objectType) => false;

		public override bool CanRead => true;

		public override bool CanWrite => false;

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}
}
