

using System.ComponentModel.DataAnnotations;

namespace IMT.PayAll.Request.PaymentInstructionRequest
{
    public class CardRequest : BaseCategory
    {
        [Required]
        public string token { get; set; }

    }
}