using IMT.App.Application.Ports.Repositories;
using IMT.App.Contracts.Requests;
using SharedKernel.Main.Domain.IMT;

namespace IMT.App.Application.Ports.Services
{
    public interface IImtProviderServiceService : IImtProviderServiceRepository
    {
        public ProviderService CreateProviderService(ProviderServiceRequest request);
        public List<ProviderService> GetAllProviderService();
        public ProviderService ProviderServiceGetById(ulong id);
        public ProviderService UpdateProviderService(ulong id, ProviderServiceRequest request);
        public Task<bool> DeleteProviderService(ulong id);
    }
}
