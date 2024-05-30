
namespace IMT.PayAll.Response
{
    public class PaymentResponse 
    {
            public string ClientPaymentId { get; set; }
            public string Id { get; set; }
            public string Status { get; set; }
            public Fees Fees { get; set; }
            public ExchangeRate ExchangeRate { get; set; }
            public string RecipientId { get; set; }
            public string PaymentInstrumentId { get; set; }

    }

    public class Fees
    {
        public FeeDetail Payer { get; set; }
        public FeeDetail Recipient { get; set; }
    }

    public class FeeDetail
    {
        public string Currency { get; set; }
        public int Value { get; set; }
    }

    public class ExchangeRate
    {
        public string Id { get; set; }
        public AmountDetail SourceAmount { get; set; }
        public AmountDetail TargetAmount { get; set; }
        public DateTime ExpirationDate { get; set; }
    }

    public class AmountDetail
    {
        public string Currency { get; set; }
        public int Value { get; set; }
    }

}