using IMT.App.Application.Ports.Services;
using IMT.App.Contracts.Requests;
using IMT.App.Infrastructure.Persistence.Repositories.ImtProvider;
using SharedKernel.Main.Domain.IMT;
using SharedKernel.Main.Infrastructure.Persistence.Configurations;

namespace IMT.App.Infrastructure.Persistence.Services.ImtProvider
{
    public class ImtProviderService : ImtProviderRepository, IImtProviderService
    {
        public ImtProviderService(ApplicationDbContext dbContext) : base(dbContext)
        {
            DependencyContainer.Initialize();
        }

        public Provider CreateProvider(ProviderRequest request)
        {
            try
            {
                return base.Add(ProviderPrepareData(request));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Task<bool> DeleteProvider(ulong id)
        {
            try
            {
                var provider = base.GetById(id);
                return base.Delete(provider);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Provider> GetProvider()
        {
            try
            {
                return base.All().ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Provider GetProviderById(ulong id)
        {
            try
            {
                return base.GetById(id);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public Provider UpdateProvider(ulong id, ProviderRequest request)
        {
            try
            {
                var provider = base.GetById(id);
                return base.Update(ProviderPrepareData(request, provider));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Provider ProviderPrepareData(ProviderRequest request, Provider? provider = null)
        {
            if (provider == null)
            {
                return new Provider
                {
                    Code = request.code,
                    Name = request.name,
                    BaseUrl = "www.thunes.com", // not yet provided, so hard coded
                    ApiKey = "AnapiKey", // not yet provided, so hard coded
                    ApiSecret = "hashedcode", // not yet provided, so hard coded
                    Status = 1, // default value
                    CreatedById = 1, // not yet provided, so hard coded
                    UpdatedById = 1, // not yet provided, so hard coded
                    CreatedAt = provider == null ? DateTime.Now : provider.CreatedAt,
                    UpdatedAt = provider != null ? DateTime.Now : DateTime.UtcNow
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
