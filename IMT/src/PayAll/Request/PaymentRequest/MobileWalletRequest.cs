
using System.ComponentModel.DataAnnotations;

namespace IMT.PayAll.Request.PaymentRequest
{
    public class MobileWalletRequest : BaseCategory
    {
        [Required]
        public string mobile_number { get; set; }
    }

}