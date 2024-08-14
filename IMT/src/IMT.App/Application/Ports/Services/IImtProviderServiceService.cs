using IMT.App.Contracts.Requests;
using SharedKernel.Main.Domain.IMT;

namespace IMT.App.Application.Ports.Services
{
    public interface IImtProviderServiceService
    {
        public ProviderService? AddProviderService(ProviderServiceRequest request);
        public ProviderService? UpdateProviderService(ulong id, ProviderServiceRequest request);
        public ProviderService? GetProviderService(ulong id);
        public Task<bool> DeleteByIdService(ulong id);
        public List<ProviderService>? GetAllProviderService();

        public ProviderService? PrepareDataProviderService(ProviderServiceRequest request, ProviderService? providerService = null);
    }
}
