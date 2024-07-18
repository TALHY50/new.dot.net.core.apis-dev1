namespace IMT.PayAll.Response.Payment
{
    public class PaymentAccountResponse
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

    public class Balance
    {
        public string currency { get; set; }
        public int value { get; set; }
    }


}
