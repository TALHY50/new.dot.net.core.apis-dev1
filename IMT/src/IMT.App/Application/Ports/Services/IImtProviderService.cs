using IMT.App.Application.Ports.Repositories;
using IMT.App.Contracts.Requests;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using SharedKernel.Main.Domain.IMT;

namespace IMT.App.Application.Ports.Services
{
    public interface IImtProviderService : IImtProviderRepository
    {
        public List<Provider> GetProvider();
        public Provider GetProviderById(ulong id);
        public Provider CreateProvider(ProviderRequest request);
        public Provider UpdateProvider(ulong id, ProviderRequest request);
        public Task<bool> DeleteProvider(ulong id);
        public Provider ProviderPrepareData(ProviderRequest request, Provider provider = null);

    }
}
