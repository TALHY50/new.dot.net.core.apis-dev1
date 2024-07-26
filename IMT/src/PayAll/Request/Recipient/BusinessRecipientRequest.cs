

using System.ComponentModel.DataAnnotations;

namespace PayAll.Request.Recipient
{
    public class BusinessRecipientRequest : BaseRecipientRequest
    {
        [Required]
        public string legal_name { get; set; }
        [Required]
        [RegularExpression("^[A-Z]{2}$", ErrorMessage = "The country code must be exactly two uppercase letters.")]
        public string country { get; set; }
        [Required]
        public string trade_name { get; set; }
        [Required]
        public string phone_number { get; set; }
        [Required]
        public string registration_number { get; set; }

       
    }
}
