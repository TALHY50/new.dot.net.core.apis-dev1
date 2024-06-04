

using System.ComponentModel.DataAnnotations;

namespace IMT.PayAll.Request.PaymentInstructionRequest
{
    public class BaseCategory
    {
        [Required]
        public string category { get; set; }
        [Required]
        public string recipient_id { get; set; }
        [Required]
        public string currency { get; set; }
    }

}