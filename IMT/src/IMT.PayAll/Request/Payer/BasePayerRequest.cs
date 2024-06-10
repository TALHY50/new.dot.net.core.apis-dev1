

using System.ComponentModel.DataAnnotations;
using IMT.PayAll.Request.PaymentRequest;

namespace IMT.PayAll.Request.Payer
{
    public class BasePayerRequest
    {
        [Required]
        public string type { get; set; }
        [Required]
        public string email { get; set; }
        public List<RegistrationAddressRequest> registration_address { get; set; }

        
    }
}
