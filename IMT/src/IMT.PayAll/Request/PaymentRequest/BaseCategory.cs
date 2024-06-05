

using System.ComponentModel.DataAnnotations;

namespace IMT.PayAll.Request.PaymentRequest
{
    public class BaseCategory
    {
        [Required]
        public string category { get; set; }
        [Required]
        public string currency { get; set; }
    }

}