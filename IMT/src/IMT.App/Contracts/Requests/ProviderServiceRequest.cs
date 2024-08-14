using SharedKernel.Main.Domain.IMT;

namespace IMT.App.Contracts.Requests
{
    public class ProviderServiceRequest
    {
        public ulong imt_provider_id { get; set; }
        public string name { get; set; }
    }
}
