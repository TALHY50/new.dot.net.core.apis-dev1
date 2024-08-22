using SharedKernel.Main.Infrastructure.Persistence.Notification.Repositories.Admin.Interface.Provider;
using SharedKernel.Main.Infrastructure.Services;

namespace SharedKernel.Main.Infrastructure.Persistence.Notification.Repositories.Admin.Provider
{
    public class ProviderRepository(Configurations.ApplicationDbContext dbContext)
        : GenericRepository<Domain.Admin.Provider, Configurations.ApplicationDbContext>(dbContext), IProviderRepository
    {
        
    }
}