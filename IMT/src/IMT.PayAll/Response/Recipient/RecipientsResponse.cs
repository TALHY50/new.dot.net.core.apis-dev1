

using IMT.PayAll.Common;
using IMT.PayAll.Response.Common;
using IMT.PayAll.Response.Discovery;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IMT.PayAll.Response.Recipient
{
    public class RecipientsResponse
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string MobileNumber { get; set; }
        public string Dob { get; set; }

        [JsonConverter(typeof(ListOrSingleItemConverter<RegistrationAddress>))]
        public List<RegistrationAddress> RegistrationAddress { get; set; }
    
        public IdentityDocumentResponse IdentityDocument { get; set; }

        public string LegalName { get; set; }
        public string Country { get; set; }
        public string TradeName { get; set; }
        public string PhoneNumber { get; set; }
        public string RegistrationNumber { get; set; }
    }
}
