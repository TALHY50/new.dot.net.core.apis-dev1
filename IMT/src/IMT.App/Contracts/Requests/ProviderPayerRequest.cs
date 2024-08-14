namespace IMT.App.Contracts.Requests
{
    public class ProviderPayerRequest
    {
        public int imtProviderId { get; set; }

        public int imtCountryId { get; set; }

        public int imtCurrencyId { get; set; }

        public sbyte? precision { get; set; }

        public decimal? increment { get; set; }
    }
}
