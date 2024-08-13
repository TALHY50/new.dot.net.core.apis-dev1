using IMT.App.Application.Ports.Repositories;
using IMT.App.Application.Ports.Services;
using IMT.App.Contracts.Requests;
using IMT.App.Infrastructure.Persistence.Repositories.ImtProviders;
using SharedKernel.Main.Domain.IMT;
using SharedKernel.Main.Infrastructure.Persistence.Configurations;

namespace IMT.App.Infrastructure.Persistence.Services.Providers
{
    public class ImtProvidersService : ImtProvidersRepository, IImtProvidersService
    {
        private readonly IImtProvidersService _providersServie;
        private readonly IImtProvidersRepository _providersRepository;
        public ImtProvidersService(ApplicationDbContext dbContext) : base(dbContext)
        {
            DependencyContainer.Initialize();
            _providersRepository = DependencyContainer.GetService<IImtProvidersRepository>();
        }
        public Provider AddProvider(ProvidersRequest request)
        {
            return base.Add(PrepareDataProvider(request));
        }

        public Provider? UpdateProvider(ulong id, ProvidersRequest request)
        {
            return base.Update(PrepareDataProvider(request, base.GetById(id)));
        }

        public List<Provider>? GetAllProviders()
        {
            return base.All().ToList();
        }

        public Task<bool> DeleteById(ulong id)
        {
            return base.Delete(base.GetById(id));
        }

        public Provider? GetProvider(ulong id)
        {
            return base.GetById(id);
        }

        public Provider? PrepareDataProvider(ProvidersRequest request, Provider? provider = null)
        {
            if (provider == null)
            {
                return new Provider
                {
                    Name = request.name,
                    Code = request.code,
                    ApiKey = request.api_key,
                    BaseUrl = request.base_url,
                    ApiSecret = request.api_secret,
                    Status = 1,
                    CreatedById = 1, // hard coded cause login not yet implemented
                    UpdatedById = 1, // hard coded cause login not yet implemented
                    CreatedAt = provider == null ? DateTime.Now : provider.CreatedAt,
                    UpdatedAt = provider != null ? DateTime.Now : DateTime.UtcNow
                };
            }
            else
            {
                provider.Name = request.name;
                provider.Code = request.code;
                provider.ApiKey = request.api_key;
                provider.BaseUrl = request.base_url;
                provider.ApiSecret = request.api_secret;
                provider.Status = 1; // Assuming status is active or valid
                provider.UpdatedById = 1; // hard-coded since login not yet implemented
                provider.UpdatedAt = DateTime.Now;

                return provider;
            }
            

  
            
        }

    }
}
