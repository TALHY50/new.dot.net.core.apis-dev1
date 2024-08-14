using IMT.App.Application.Ports.Repositories;
using IMT.App.Application.Ports.Services;
using IMT.App.Contracts.Requests;
using IMT.App.Infrastructure.Persistence.Repositories.ImtProviderPrayers;
using SharedKernel.Main.Domain.IMT;
using SharedKernel.Main.Infrastructure.Persistence.Configurations;

namespace IMT.App.Infrastructure.Persistence.Services.ProviderPrayers
{
    public class ImtProviderPrayersService : ImtProviderPrayersRepository, IImtProviderPrayersService
    {
        private readonly IImtProviderPrayersService _providerPrayersService;
        private readonly IImtProviderPrayersRepository _providerPrayersRepository;
        public ImtProviderPrayersService(ApplicationDbContext dbContext) : base(dbContext)
        {
            DependencyContainer.Initialize();
            _providerPrayersRepository = DependencyContainer.GetService<IImtProviderPrayersRepository>();
        }

        public ProviderPayer AddProviderPrayer(ProviderPrayerRequest request)
        {
            return base.Add(PrepareDataProviderPrayer(request));
        }

        public ProviderPayer UpdateProviderPrayer(ulong id, ProviderPrayerRequest request)
        {
            return base.Update(PrepareDataProviderPrayer(request, base.GetById(id)));
        }

        public ProviderPayer GetProviderPrayer(ulong id)
        {
            return base.GetById(id);
        }

        public Task<bool> DeleteByIdPrayer(ulong id)
        {
            return base.Delete(base.GetById(id));
        }

        public List<ProviderPayer> GetAllProviderPrayer()
        {
            return base.All().ToList();
        }


        public ProviderPayer? PrepareDataProviderPrayer(ProviderPrayerRequest request, ProviderPayer providerPrayer = null)
        {
            if (providerPrayer == null)
            {
                return new ProviderPayer
                {
                    ImtProviderId = 1, //hard coded
                    ImtCountryId = 1, //hard coded
                    ImtCurrencyId = 1, //hard coded
                    ImtProviderServiceId = request.imt_provider_service_id,
                    RemotePayerId = request.remote_payer_id,
                    Precision = request.precision,
                    Increment = request.increment,
                    CreatedAt = providerPrayer == null ? DateTime.Now : providerPrayer.CreatedAt,
                    UpdatedAt = providerPrayer == null ? DateTime.Now : DateTime.UtcNow
                };
            }
            else
            {
                providerPrayer.ImtProviderServiceId = request.imt_provider_service_id;
                providerPrayer.RemotePayerId = request.remote_payer_id;
                providerPrayer.Precision = request.precision;
                providerPrayer.Increment = request.increment;
                providerPrayer.UpdatedAt = DateTime.Now;

                return providerPrayer;
            }
        }
    }
}
