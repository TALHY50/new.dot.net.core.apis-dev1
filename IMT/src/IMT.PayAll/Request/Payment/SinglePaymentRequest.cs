
using System.ComponentModel.DataAnnotations;
using IMT.PayAll.Request.Common;
using IMT.PayAll.Request.PaymentRequest;
using IMT.PayAll.Request.Recipient;


namespace IMT.PayAll.Request.Payment
{
    public class SinglePaymentRequest
    {
        public string client_payment_id { get; set; }
        public object recipient { get; set; }
        public object payment_instrument { get; set; }
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