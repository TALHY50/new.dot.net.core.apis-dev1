using Thunes.Response.Discovery.Common;

namespace Thunes.Response.Discovery
{
    public class PayerResponse
    {
        public int id { get; set; }
        public string name { get; set; }
        public int precision { get; set; }
        public double increment { get; set; }
        public string currency { get; set; }
        public string country_iso_code { get; set; }
        public Service service { get; set; }
      //  public Dictionary<string, TransactionType> transaction_types { get; set; }
        public TransactionTypes transaction_types { get; set; }
    }

}