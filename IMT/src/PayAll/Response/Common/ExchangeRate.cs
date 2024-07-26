namespace PayAll.Response.Common
{
    public class ExchangeRate
    {
        public Guid id { get; set; }
        public SourceAmount source_amount { get; set; }
        public TargetAmount target_amount { get; set; }
        public DateTime expiration_date { get; set; }
    }
}
