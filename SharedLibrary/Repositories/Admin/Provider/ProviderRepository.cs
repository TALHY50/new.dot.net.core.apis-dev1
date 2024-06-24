
using ADMIN.Infrastructure.Persistence.Configurations;
using Microsoft.Extensions.Configuration;
using SharedLibrary.Models.Admin.Provider;
using SharedLibrary.Repositories.Admin.Interface.Provider;
using SharedLibrary.Services;

namespace SharedLibrary.Repositories.Admin.Provider
{
    public class ProviderRepository(ApplicationDbContext dbContext)
        : GenericRepository<AdminProvider, ApplicationDbContext>(dbContext), IProviderRepository
    {
        
    }
}