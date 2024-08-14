using ErrorOr;
using Google.Protobuf.WellKnownTypes;
using IMT.App.Application.Ports.Repositories;
using IMT.App.Application.Ports.Services;
using IMT.App.Contracts.Requests;
using IMT.App.Infrastructure.Persistence.Repositories.ImtProvider;
using SharedKernel.Main.Domain.IMT;
using SharedKernel.Main.Infrastructure.Persistence.Configurations;

namespace IMT.App.Infrastructure.Persistence.Services.ImtProviderService
{
    public class ImtProviderService : ImtProviderRepository, IImtProviderService
    {
        public IImtProviderRepository _providerRepository;
        public ImtProviderService(ApplicationDbContext dbContext) : base(dbContext)
        {
            DependencyContainer.Initialize();
            _providerRepository = DependencyContainer.GetService<IImtProviderRepository>();
        }

        public Provider CreateProvider(ProviderRequest request)
        {
            return base.Add(PrepareProvider(request));
        }

        public Task<bool> DeleteProviderById(ulong Id)
        {
            return base.Delete(GetById(Id));
        }

        public List<Provider> GetAllProvider()
        {
            return base.All().ToList();
        }

        public Provider GetProviderById(ulong Id)
        {
            Provider obj = base.GetById(Id);
            return obj;
        }
        public Provider UpdateProviderById(ulong Id, ProviderRequest request)
        {
            return base.Update(PrepareProvider(request, base.GetById(Id)));
        }
        public Provider PrepareProvider(ProviderRequest request, Provider? provider = null)
        {
            if (provider == null)
            {
                return new Provider
                {
                    Code = request.code,
                    Name = request.name,
                    BaseUrl = "Alamin.com",
                    ApiKey = "alaminapi",
                    ApiSecret = "goponapi",
                    Status = 1,
                    CreatedById = 84,
                    UpdatedById = 34,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };
            }
            else
            {
                provider.Code = request.code;
                provider.Name = request.name;
                provider.UpdatedAt = DateTime.UtcNow;
                return provider;
            }
        }

        
    }
    
}
