using IMT.App.Application.Ports.Repositories;
using IMT.App.Contracts.Requests;
using SharedKernel.Main.Domain.IMT;

namespace IMT.App.Application.Ports.Services
{
    public interface IImtProviderPayersService : IImtProviderPayersRepository
    {
        public List<ProviderPayer> GetProviderPayers();

        public ProviderPayer GetProviderPayersById(ulong id);

        public ProviderPayer CreateProviderPayers(ProviderPayerRequest request);

        public ProviderPayer UpdateProviderPayers(ulong id, ProviderPayerRequest request);

        public Task<bool> DeleteProviderPayers(ulong id);

        public ProviderPayer ProviderPayerPrepareData(ProviderPayerRequest request,ProviderPayer providerPayer = null);

    }
}
