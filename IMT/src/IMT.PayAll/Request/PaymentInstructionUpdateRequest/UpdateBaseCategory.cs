

using System.ComponentModel.DataAnnotations;

namespace IMT.PayAll.Request.PaymentInstructionUpdateRequest
{
    public class UpdateBaseCategory
    {
        [Required]
        public string category { get; set; }

        [Required]
        public string currency { get; set; }
    }

}