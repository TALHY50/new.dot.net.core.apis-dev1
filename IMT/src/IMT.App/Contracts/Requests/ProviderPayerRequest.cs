namespace IMT.App.Contracts.Requests
{
    public class ProviderPayerRequest
    {
        //public ulong id { get; set; }
      //  public int imt_provider_id { get; set; } = 1;
      //  public int imt_country_id { get; set; } = 1;
      //  public int imt_currency_id { get; set; } = 1;
        public int imt_provider_service_id { get; set; }
        public int remote_payer_id { get; set; }
        public sbyte precision { get; set; }
        public decimal increment { get; set; }
        //public DateTime created_at { get; set; }
        //public DateTime updated_at { get; set; }
    }
}
