
namespace IMT.PayAll.Response
{
    public class PaymentResponse 
    {
        public string client_payment_id { get; set; }
        public string id { get; set; }
        public string status { get; set; }
        public Fees fees { get; set; }
        public ExchangeRate exchange_rate { get; set; }
        public string recipient_id { get; set; }
        public string payment_instrument_id { get; set; }

    }

    public class ExchangeRate
    {
        public string id { get; set; }
        public SourceAmount source_amount { get; set; }
        public TargetAmount target_amount { get; set; }
        public DateTime expiration_date { get; set; }
    }

    public class Fees
    {
        public Payer payer { get; set; }
        public Recipient recipient { get; set; }
    }

    public class Payer
    {
        public string currency { get; set; }
        public int value { get; set; }
    }

    public class Recipient
    {
        public string currency { get; set; }
        public int value { get; set; }
    }

    public class SourceAmount
    {
        public string currency { get; set; }
        public int value { get; set; }
    }

    public class TargetAmount
    {
        public string currency { get; set; }
        public int value { get; set; }
    }


}