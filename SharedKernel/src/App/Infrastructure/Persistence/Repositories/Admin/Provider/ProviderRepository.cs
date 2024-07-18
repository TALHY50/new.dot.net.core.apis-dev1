using App.Domain.Admin.Provider;
using App.Infrastructure.Persistence.Configurations;
using App.Infrastructure.Persistence.Repositories.Admin.Interface.Provider;
using App.Infrastructure.Services;

namespace App.Infrastructure.Persistence.Repositories.Admin.Provider
{
    public class ProviderRepository(ApplicationDbContext dbContext)
        : GenericRepository<AdminProvider, ApplicationDbContext>(dbContext), IProviderRepository
    {
        
    }
}