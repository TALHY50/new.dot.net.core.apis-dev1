using ADMIN.Application.Ports.Repositories.Interface.Provider;
using ADMIN.Contracts.Requests;
using ADMIN.Core.Entities.AdminProvider;
using ADMIN.Infrastructure.Persistence.Configurations;
using Microsoft.Extensions.Configuration;
using SharedLibrary.Services;

namespace ADMIN.Infrastructure.Persistence.Repositories.Provider
{
    public class ProviderRepository(ApplicationDbContext dbContext)
        : GenericRepository<AdminProvider, ApplicationDbContext>(dbContext), IProviderRepository
    {
        
    }
}