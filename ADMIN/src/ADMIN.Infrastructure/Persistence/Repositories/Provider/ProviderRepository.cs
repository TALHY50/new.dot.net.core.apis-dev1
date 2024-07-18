using ADMIN.Application.Ports.Repositories.Provider;
using ADMIN.Core.Entities.Provider;
using ADMIN.Infrastructure.Persistence.Configurations;
using Microsoft.Extensions.Configuration;
using SharedKernel.Services;

namespace ADMIN.Infrastructure.Persistence.Repositories.Provider
{
    public class ProviderRepository(ApplicationDbContext dbContext)
        : GenericRepository<AdminProvider, ApplicationDbContext>(dbContext), IProviderRepository
    {
        
    }
}