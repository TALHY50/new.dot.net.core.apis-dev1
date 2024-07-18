
using System.ComponentModel.DataAnnotations;

namespace IMT.PayAll.Request.PaymentInstructionUpdateRequest
{
    public class MobileWalletUpdateRequest : UpdateBaseCategory
    {
        [Required]
        public string mobile_number { get; set; }
    }

}