
using System.ComponentModel.DataAnnotations;
using IMT.PayAll.Request.Common;
using IMT.PayAll.Request.PaymentRequest;

namespace IMT.PayAll.Request
{
    public class CreatePaymentRequest
    {
        public string client_payment_id { get; set; }
        public Recipient recipient { get; set; }
        public PaymentInstrument payment_instrument { get; set; }
        public string recipient_id { get; set; }
        public string payment_instrument_id { get; set; }
        [Required]
        public string source_account_id { get; set; }
        [Required]
        public Amount amount { get; set; }
        public string exchange_rate_id { get; set; }
        public string carded_rate_id { get; set; }
        [Required]
        public Kyt kyt { get; set; }


    }

}