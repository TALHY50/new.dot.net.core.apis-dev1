
using System.ComponentModel.DataAnnotations;

namespace PayAll.Request.PaymentInstructionRequest
{
    public class MobileWalletRequest : BaseCategory
    {
        [Required]
        public string mobile_number { get; set; }
    }

}