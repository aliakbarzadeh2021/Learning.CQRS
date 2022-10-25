using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Learning.CQRS.Infrastructure.Helpers;

namespace Learning.CQRS.ReadApi.Activator.Helper
{
    public class JsonDateTimeConverter : DateTimeConverterBase
    {
        //...
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((DateTime)value).FaDate());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return reader.Value == null || string.IsNullOrEmpty(reader.Value.ToString()) ? DateTime.MinValue : reader.Value.ToString().ConvertToDate();
        }
    }
}
