using IMT.App.Application.Ports.Repositories;
using IMT.App.Application.Ports.Services;
using IMT.App.Contracts.Requests;
using IMT.App.Infrastructure.Persistence.Repositories.ImtProviderPayers;
using SharedKernel.Main.Domain.IMT;
using SharedKernel.Main.Infrastructure.Persistence.Configurations;

namespace IMT.App.Infrastructure.Persistence.Services.ProviderPayers
{
    public class ImtProviderPayersService : ImtProviderPayersRepository, IImtProviderPayersService
    {
        private readonly IImtProviderPayersService _providerPayersService;
        private readonly IImtProviderPayersRepository _ProviderPayersRepository;
        public ImtProviderPayersService(ApplicationDbContext dbContext) : base(dbContext)
        {
            DependencyContainer.Initialize();
            _ProviderPayersRepository = DependencyContainer.GetService<IImtProviderPayersRepository>();
        }

        public ProviderPayer AddProviderPayer(ProviderPayerRequest request)
        {
            return base.Add(PrepareDataProviderPayer(request));
        }

        public ProviderPayer UpdateProviderPayer(ulong id, ProviderPayerRequest request)
        {
            return base.Update(PrepareDataProviderPayer(request, base.GetById(id)));
        }

        public ProviderPayer GetProviderPayer(ulong id)
        {
            return base.GetById(id);
        }

        public Task<bool> DeleteByIdPayer(ulong id)
        {
            return base.Delete(base.GetById(id));
        }

        public List<ProviderPayer> GetAllProviderPayer()
        {
            return base.All().ToList();
        }


        public ProviderPayer? PrepareDataProviderPayer(ProviderPayerRequest request, ProviderPayer ProviderPayer = null)
        {
            if (ProviderPayer == null)
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
                    CreatedAt = ProviderPayer == null ? DateTime.Now : ProviderPayer.CreatedAt,
                    UpdatedAt = ProviderPayer == null ? DateTime.Now : DateTime.UtcNow
                };
            }
            else
            {
                ProviderPayer.ImtProviderServiceId = request.imt_provider_service_id;
                ProviderPayer.RemotePayerId = request.remote_payer_id;
                ProviderPayer.Precision = request.precision;
                ProviderPayer.Increment = request.increment;
                ProviderPayer.UpdatedAt = DateTime.Now;

                return ProviderPayer;
            }
        }
    }
}
