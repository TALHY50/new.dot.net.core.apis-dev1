using IMT.App.Application.Ports.Repositories;
using IMT.App.Application.Ports.Services;
using IMT.App.Contracts.Requests;
using IMT.App.Infrastructure.Persistence.Repositories.ImtProviderPayer;
using IMT.App.Infrastructure.Persistence.Services.ImtProviderService;
using SharedKernel.Main.Infrastructure.Persistence.Configurations;
using PPayer = SharedKernel.Main.Domain.IMT.ProviderPayer;
namespace IMT.App.Infrastructure.Persistence.Services.ProviderPayer
{
    public class ImtProviderPayerService : ImtProviderPayerRepository, IImtProviderPayerService
    {
        public IImtProviderPayerRepository _providerPayerRepository;
        public ImtProviderPayerService(ApplicationDbContext dbContext) : base(dbContext)
        {
            DependencyContainer.Initialize();
            _providerPayerRepository = DependencyContainer.GetService<IImtProviderPayerRepository>();
        }

        public PPayer CreateProviderPayer(ProviderPayerRequest request)
        {
            return base.Add(PrepareProviderPayer(request));
        }

        public Task<bool> DeleteProviderPayerById(ulong Id)
        {
            return base.Delete(GetById(Id));
        }

        public List<PPayer> GetAllProviderPayer()
        {
            return base.All().ToList();
        }

        public PPayer GetProviderPayerById(ulong Id)
        {
            PPayer obj = base.GetById(Id);
            return obj;
        }
        public PPayer UpdateProviderPayerById(ulong Id, ProviderPayerRequest request)
        {
            return base.Update(PrepareProviderPayer(request, base.GetById(Id)));
        }
        public PPayer PrepareProviderPayer(ProviderPayerRequest request, PPayer? provider = null)
        {
            if (provider == null)
            {
                return new PPayer
                {
                    ImtProviderId = request.imtProviderId,
                    ImtCountryId = request.imtCountryId,
                    ImtCurrencyId = request.imtCurrencyId,
                    ImtProviderServiceId = 84,
                    RemotePayerId = 34,
                    Precision = request.precision,
                    Increment = request.increment,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };
            }
            else
            {
                provider.ImtProviderId = request.imtProviderId;
                provider.ImtCountryId = request.imtCountryId;
                provider.ImtCurrencyId = request.imtCurrencyId;
                provider.Precision = request.precision;
                provider.Increment = request.increment;
                provider.UpdatedAt = DateTime.UtcNow;
                return provider;
            }
        }
    }
}
