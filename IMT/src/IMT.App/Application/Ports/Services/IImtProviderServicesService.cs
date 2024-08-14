using IMT.App.Application.Ports.Repositories;
using IMT.App.Contracts.Requests;
using IMT.App.Infrastructure.Persistence.Repositories.ImtProviderServices;
using SharedKernel.Main.Domain.IMT;

namespace IMT.App.Application.Ports.Services
{
    public interface IImtProviderServicesService : IImtProviderServicesRepository 
    {
        public List<ProviderService> GetAllProviderServices();
        public ProviderService GetProviderServicesById(ulong Id);
        public ProviderService CreateProviderServices(ProviderServicesRequest request);
        public ProviderService UpdateProviderServices(ulong Id, ProviderServicesRequest request);
        public Task<bool> DeleteProviderServices(ulong Id);

        public ProviderService ProviderServicePrepareData(ProviderServicesRequest request, ProviderService providerService = null);
    }
}
