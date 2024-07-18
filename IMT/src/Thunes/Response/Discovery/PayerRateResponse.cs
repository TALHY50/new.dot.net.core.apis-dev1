namespace Thunes.Response.Discovery
{
    public class PayerRateResponse
    {
        public string destination_currency { get; set; }
        public Rates rates { get; set; }
    }
    public class Rates
    {
        public C2C C2C { get; set; }
    }


    public class C2C
    {
        public List<EUR> EUR { get; set; }
    }

    public class EUR
    {
        public float source_amount_min { get; set; }
        public float source_amount_max { get; set; }
        public double wholesale_fx_rate { get; set; }
    }
}