
using System.ComponentModel.DataAnnotations;
using IMT.PayAll.Request.Common;

namespace IMT.PayAll.Request.PaymentRequest
{
    public class KytRequest
    {
        [Required]
        [RegularExpression("^[A-Z]{2}$", ErrorMessage = "The country code must be exactly two uppercase letters.")]
        public string destination_country { get; set; }
        [Required]
        public string payment_purpose { get; set; }
        [Required]
        public string commercial_activity { get; set; }
        [Required]
        public string payment_description { get; set; }
        public List<SupportingDocument> supporting_documents { get; set; }
    }

}
