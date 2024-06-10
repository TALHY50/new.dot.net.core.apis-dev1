

using IMT.PayAll.Request.PaymentRequest;

namespace IMT.PayAll.Request.Payer
{
    public class PayerRequest : BasePayerRequest
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string middle_name { get; set; }
        public string mobile_number { get; set; }
        public DateOnly dob { get; set; }
        public string legal_name { get; set; }
        public string country { get; set; }
        public string trade_name { get; set; }
        public string phone_number { get; set; }
        public string registration_number { get; set; }
        public IdentityDocumentRequest identity_document { get; set; }

        
    }
}
