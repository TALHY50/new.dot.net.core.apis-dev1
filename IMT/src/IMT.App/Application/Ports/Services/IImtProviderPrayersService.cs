using IMT.App.Application.Ports.Repositories;
using IMT.App.Contracts.Requests;
using SharedKernel.Main.Domain.IMT;

namespace IMT.App.Application.Ports.Services
{
    public interface IImtProviderPrayersService : IImtProviderPrayersRepository
    {
        public ProviderPayer AddProviderPrayer(ProviderPrayerRequest request);
        public ProviderPayer UpdateProviderPrayer(ulong id, ProviderPrayerRequest request);
        public ProviderPayer GetProviderPrayer(ulong id);
        public Task<bool> DeleteByIdPrayer(ulong id);
        public List<ProviderPayer> GetAllProviderPrayer();
        public ProviderPayer? PrepareDataProviderPrayer(ProviderPrayerRequest request, ProviderPayer providerPayer = null);
    }
}
