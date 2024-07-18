using ADMIN.Application.Application.Ports.Repositories.Provider;
using ADMIN.Application.Domain.Provider;
using ADMIN.Application.Infrastructure.Persistence.Configurations;
using SharedKernel.Infrastructure.Services;

namespace ADMIN.Application.Infrastructure.Persistence.Repositories.Provider
{
    public class ProviderRepository(ApplicationDbContext dbContext)
        : GenericRepository<AdminProvider, ApplicationDbContext>(dbContext), IProviderRepository
    {
        
    }
}