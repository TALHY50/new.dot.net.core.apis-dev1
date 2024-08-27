using SharedKernel.Main.Infrastructure.Services;
using SharedKernel.Main.Notification.Infrastructure.Persistence.Repositories.Admin.Interface.Provider;

namespace SharedKernel.Main.Notification.Infrastructure.Persistence.Repositories.Admin.Provider
{
    public class ProviderRepository(Configurations.ApplicationDbContext dbContext)
        : GenericRepository<Main.IMT.Domain.Entities.Provider, Configurations.ApplicationDbContext>(dbContext), IProviderRepository
    {
        
    }
}