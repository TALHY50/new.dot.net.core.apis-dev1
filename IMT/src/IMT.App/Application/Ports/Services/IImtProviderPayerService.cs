using IMT.App.Application.Ports.Repositories;
using IMT.App.Contracts.Requests;
using SharedKernel.Main.Domain.IMT;

namespace IMT.App.Application.Ports.Services
{
    public interface IImtProviderPayerService : IImtProviderPayerRepository
    {
        public ProviderPayer CreateProviderPayer(ProviderPayerRequest request);
        public List<ProviderPayer> GetAllProviderPayer();
        public ProviderPayer GetProviderPayerById(ulong Id);
        public ProviderPayer UpdateProviderPayerById(ulong Id, ProviderPayerRequest request);
        public Task<bool> DeleteProviderPayerById(ulong Id);
    }
}
