using IMT.App.Application.Ports.Repositories;
using IMT.App.Contracts.Requests;
using SharedKernel.Main.Domain.IMT;

namespace IMT.App.Application.Ports.Services
{
    public interface IImtProvidersService : IImtProvidersRepository
    {
        public Provider AddProvider(ProvidersRequest request);
        public Provider? UpdateProvider(ulong id ,ProvidersRequest request);
        public Provider? GetProvider(ulong id);
        public List<Provider>? GetAllProviders();
        public Task<bool> DeleteById(ulong id);
        public Provider? PrepareDataProvider(ProvidersRequest request, Provider? provider = null);
    }
}
