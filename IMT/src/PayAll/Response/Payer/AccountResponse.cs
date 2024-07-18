using PayAll.Response.Payment;

namespace PayAll.Response.Payer
{
    public class AccountResponse
    {
        public Guid id { get; set; }
        public string owner_id { get; set; }
        public string owner_name { get; set; }
        public DateTime created { get; set; }
        public string number { get; set; }
        public string name { get; set; }
        public string currency { get; set; }
        public Balance balance { get; set; }
    }
}
