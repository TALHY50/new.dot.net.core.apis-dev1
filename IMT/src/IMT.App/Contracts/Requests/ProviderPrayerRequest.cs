using SharedKernel.Main.Domain.IMT;

namespace IMT.App.Contracts.Requests
{
    public class ProviderPrayerRequest
    {
        public ulong imt_provider_service_id { get; set; }
        public ulong remote_payer_id { get; set; }
        public sbyte precision { get; set; }
        public decimal increment { get; set; }
    }
}
