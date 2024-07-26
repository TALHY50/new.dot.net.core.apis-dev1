namespace PayAll.Response.Exchange
{
    public class GetCardedExchangeRateResponse
    {
        public List<Rate> rates { get; set; }
    }
    public class Rate
    {
        public Guid id { get; set; }
        public string from_currency { get; set; }
        public string to_currency { get; set; }
        public DateTime valid_from { get; set; }
        public DateTime valid_to { get; set; }
        public string payment_instrument_category { get; set; }
        public double rate { get; set; }
        public List<Tier> tiers { get; set; }
    }
    public class Tier
    {
        public Guid id { get; set; }
        public int from_amount { get; set; }
        public double rate { get; set; }
    }

}
