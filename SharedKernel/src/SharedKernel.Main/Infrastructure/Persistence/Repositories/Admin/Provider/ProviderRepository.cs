using SharedKernel.Main.Domain.Admin.Provider;
using SharedKernel.Main.Infrastructure.Persistence.Configurations;
using SharedKernel.Main.Infrastructure.Persistence.Repositories.Admin.Interface.Provider;
using SharedKernel.Main.Infrastructure.Services;

namespace SharedKernel.Main.Infrastructure.Persistence.Repositories.Admin.Provider
{
    public class ProviderRepository(ApplicationDbContext dbContext)
        : GenericRepository<Domain.Admin.Provider.Provider, ApplicationDbContext>(dbContext), IProviderRepository
    {
        
    }
}