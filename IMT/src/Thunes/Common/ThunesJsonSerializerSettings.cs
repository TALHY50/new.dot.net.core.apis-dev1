using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Thunes.Common
{
    public class ThunesJsonSerializerSettings
    {
        public static JsonSerializerSettings Settings { get; set; } = new JsonSerializerSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore,
            Converters = new List<JsonConverter>
            {
                new StringEnumConverter()
            }
        };
    }
}