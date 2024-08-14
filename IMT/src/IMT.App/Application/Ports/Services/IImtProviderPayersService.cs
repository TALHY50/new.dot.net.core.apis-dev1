using IMT.App.Application.Ports.Repositories;
using IMT.App.Contracts.Requests;
using SharedKernel.Main.Domain.IMT;

namespace IMT.App.Application.Ports.Services
{
    public interface IImtProviderPayersService : IImtProviderPayersRepository
    {
        public ProviderPayer AddProviderPayer(ProviderPayerRequest request);
        public ProviderPayer UpdateProviderPayer(ulong id, ProviderPayerRequest request);
        public ProviderPayer GetProviderPayer(ulong id);
        public Task<bool> DeleteByIdPayer(ulong id);
        public List<ProviderPayer> GetAllProviderPayer();
        public ProviderPayer? PrepareDataProviderPayer(ProviderPayerRequest request, ProviderPayer providerPayer = null);
    }
}
