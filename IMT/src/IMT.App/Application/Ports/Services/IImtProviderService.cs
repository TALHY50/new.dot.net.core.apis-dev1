using IMT.App.Application.Ports.Repositories;
using IMT.App.Contracts.Requests;
using SharedKernel.Main.Domain.IMT;

namespace IMT.App.Application.Ports.Services
{
    public interface IImtProviderService : IImtProviderRepository 
    {
        public Provider CreateProvider(ProviderRequest request);
        public List<Provider> GetAllProvider();
        public Provider GetProviderById(ulong Id);
        public Provider UpdateProviderById(ulong Id, ProviderRequest request);
        public Task<bool> DeleteProviderById(ulong Id);
        //public Provider PrepareProvider(ProviderRequest request);
    }
}
