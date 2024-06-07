

using System.ComponentModel.DataAnnotations;

namespace IMT.PayAll.Request.Recipient
{
    public class BusinessRecipientRequest : BaseRecipientRequest
    {
        [Required]
        public string legal_name { get; set; }
        [Required]
        public string country { get; set; }
        [Required]
        public string trade_name { get; set; }
        [Required]
        public string phone_number { get; set; }
        [Required]
        public string registration_number { get; set; }

       
    }
}
