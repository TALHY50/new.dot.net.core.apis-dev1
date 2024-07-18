using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PayAll.Common
{
    public class ListOrSingleItemConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(List<T>);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            List<T> items = new List<T>();

            if (token.Type == JTokenType.Array)
            {
                items = token.ToObject<List<T>>(serializer);
            }
            else if (token.Type == JTokenType.Object)
            {
                items.Add(token.ToObject<T>(serializer));
            }

            return items;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            List<T> items = (List<T>)value;

            if (items.Count == 1)
            {
                serializer.Serialize(writer, items[0]);
            }
            else
            {
                serializer.Serialize(writer, items);
            }
        }
    }
}
