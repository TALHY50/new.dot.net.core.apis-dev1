using SharedKernel.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.IMT.Domain.Entities.Duplicates;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Context;
using SharedKernel.Main.Infrastructure.Services;

namespace SharedKernel.Main.Infrastructure.Persistence.Imt.Repositories.Repositories
{
    public class ProviderRepository(ApplicationDbContext dbContext) 
        : GenericRepository<Provider, ApplicationDbContext>(dbContext), IImtProviderRepository
    {
    }
}
