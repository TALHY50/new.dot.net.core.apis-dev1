

using System.ComponentModel.DataAnnotations;

namespace IMT.PayAll.Request.PaymentRequest
{
    public class PersonRecipient : BaseRecipient
    {
        [Required]
        public string first_name { get; set; }
        [Required]
        public string last_name { get; set; }
        [Required]
        public string middle_name { get; set; }
        [Required]
        public string mobile_number { get; set; }
        public DateOnly dob { get; set; }

        public IdentityDocument identity_document { get; set; }
    }
}
