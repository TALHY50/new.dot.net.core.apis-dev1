using System.ComponentModel.DataAnnotations;
using PayAll.Request.Common;
using PayAll.Request.PaymentRequest;
using PayAll.Request.Recipient;

namespace PayAll.Request.Payment
{
    public class CreatePaymentRequest
    {
        public string client_payment_id { get; set; }
        public RecipientRequest? recipient { get; set; }
        public PaymentInstrumentRequest? payment_instrument { get; set; }
        public string recipient_id { get; set; }
        public string payment_instrument_id { get; set; }
        [Required]
        public string source_account_id { get; set; }
        [Required]
        public Amount amount { get; set; }
        public string exchange_rate_id { get; set; }
        public string carded_rate_id { get; set; }
        [Required]
        public KytRequest kyt { get; set; }


    }

}