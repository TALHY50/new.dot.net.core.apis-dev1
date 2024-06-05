
using System.ComponentModel.DataAnnotations;

namespace IMT.PayAll.Request.PaymentRequest
{
    public class Recipient : BaseRecipient
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
        public IdentityDocument identity_document { get; set; }
    }
}
