using Newtonsoft.Json;
using PayAll.Common;
using PayAll.Response.Common;

namespace PayAll.Response.Recipient
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
       [JsonConverter(typeof(ListOrSingleItemConverter<RegistrationAddressResponse>))]
        public List<RegistrationAddressResponse> registration_address { get; set; }
        public IdentityDocumentResponse identity_document { get; set; }
        public string legal_name { get; set; }
        public string country { get; set; }
        public string trade_name { get; set; }
        public string phone_number { get; set; }
        public string registration_number { get; set; }
    }
}
