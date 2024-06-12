using System.ComponentModel.DataAnnotations;
using IMT.PayAll.Model;
using IMT.PayAll.Response.Common;

namespace IMT.PayAll.Request.Exchange
{
    public class RequestExchangeRate
    {
        public SourceAmount source_amount { get; set; }
        public TargetAmount target_amount { get; set; }
        public string source_account_id { get; set; }
        [MaxLength(3)]
        [MinLength(3)]
        public string source_currency { get; set; }
        public string recipient_instrument_id { get; set; }
        public string payment_instrument_category { get; set; }
        public string payment_type { get; set; }
        [MaxLength(3)]
        [MinLength(3)]
        public string target_currency { get; set; }
        [RegularExpression("^[A-Z]{2}$", ErrorMessage = "The country code must be exactly two uppercase letters.")]
        public string destination_country { get; set; }


    }

}