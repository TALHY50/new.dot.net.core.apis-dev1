using SharedKernel.Domain.Admin.Provider;
using SharedKernel.Infrastructure.Persistence.Configurations;
using SharedKernel.Infrastructure.Persistence.Repositories.Admin.Interface.Provider;
using SharedKernel.Infrastructure.Services;

namespace SharedKernel.Infrastructure.Persistence.Repositories.Admin.Provider
{
    public class ProviderRepository(ApplicationDbContext dbContext)
        : GenericRepository<AdminProvider, ApplicationDbContext>(dbContext), IProviderRepository
    {
        
    }
}