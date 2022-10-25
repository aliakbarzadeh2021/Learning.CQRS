using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Learning.CQRS.WriteApi.Activator.Helper
{
    public static class HttpConfigurationExtensions
    {
        public static void UseJsonFormatters(this HttpConfiguration config)
        {
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Formatting.Indented;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new JsonDateTimeConverter());
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new KeyValueConverter());
            
        }
    }
}
