

using System.ComponentModel.DataAnnotations;

namespace IMT.PayAll.Request.PaymentRequest
{
    public class BaseRecipient
    {
        [Required]
        public string type { get; set; }
        [Required]
        public string email { get; set; }
        public List<RegistrationAddress> registration_address { get; set; }
    }
}
