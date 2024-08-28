using IMT.App.Application.Interfaces.Repositories;
using IMT.App.Domain.Entities.Duplicates;
using IMT.App.Infrastructure.Persistence.Context;
using SharedKernel.Main.Infrastructure.Services;

namespace IMT.App.Infrastructure.Persistence.Repositories
{
    public class ProviderRepository(ApplicationDbContext dbContext) 
        : GenericRepository<Provider, ApplicationDbContext>(dbContext), IImtProviderRepository
    {
    }
}
