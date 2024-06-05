

using IMT.PayAll.Request.Common;


namespace IMT.PayAll.Request
{
    public class SinglePaymentRequest
    {
        public string client_payment_id { get; set; }
        public object recipient { get; set; }
        public object payment_instrument { get; set; }
        public string recipient_id { get; set; }
        public string payment_instrument_id { get; set; }
        public string source_account_id { get; set; }
        public Amount amount { get; set; }
        public string exchange_rate_id { get; set; }
        public string carded_rate_id { get; set; }
        public object kyt { get; set; }

    }

}