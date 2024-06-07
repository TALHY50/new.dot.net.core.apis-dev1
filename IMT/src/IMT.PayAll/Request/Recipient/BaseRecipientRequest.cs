

using System.ComponentModel.DataAnnotations;
using IMT.PayAll.Request.PaymentRequest;

namespace IMT.PayAll.Request.Recipient
{
    public class BaseRecipientRequest
    {
        [Required]
        public string type { get; set; }
        [Required]
        public string email { get; set; }
        public List<RegistrationAddressRequest> registration_address { get; set; }

        
    }
}
