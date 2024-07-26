

using System.ComponentModel.DataAnnotations;

namespace PayAll.Request.PaymentInstructionRequest
{
    public class CardRequest : BaseCategory
    {
        [Required]
        public string token { get; set; }

    }
}