

using IMT.PayAll.Response.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IMT.PayAll.Response
{
    public class RecipientsResponse
    {
        public Guid id { get; set; }
        public string type { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string middle_name { get; set; }
        public string mobile_number { get; set; }
        public string dob { get; set; }
        [JsonConverter(typeof(RegistrationAddressConverter))]
        public List<RegistrationAddressResponse> registration_address { get; set; }
        public IdentityDocumentResponse identity_document { get; set; }
        public string legal_name { get; set; }
        public string country { get; set; }
        public string trade_name { get; set; }
        public string phone_number { get; set; }
        public string registration_number { get; set; }
    }

    #region Json Custom Converter By porosh

 

    public class RegistrationAddressConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(List<RegistrationAddressResponse>);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            List<RegistrationAddressResponse> addresses = new List<RegistrationAddressResponse>();

            if (token.Type == JTokenType.Array)
            {
                addresses = token.ToObject<List<RegistrationAddressResponse>>();
            }
            else if (token.Type == JTokenType.Object)
            {
                addresses.Add(token.ToObject<RegistrationAddressResponse>());
            }

            return addresses;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            List<RegistrationAddressResponse> addresses = (List<RegistrationAddressResponse>)value;

            if (addresses.Count == 1)
            {
                serializer.Serialize(writer, addresses[0]);
            }
            else
            {
                serializer.Serialize(writer, addresses);
            }
        }
    }


    #endregion
}
