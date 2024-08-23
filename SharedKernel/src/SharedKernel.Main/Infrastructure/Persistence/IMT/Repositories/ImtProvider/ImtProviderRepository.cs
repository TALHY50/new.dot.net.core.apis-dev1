using SharedKernel.Main.Application.Interfaces.Repositories.IMT.Repositories;
using SharedKernel.Main.Domain.IMT.Entities;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Context;
using SharedKernel.Main.Infrastructure.Services;

namespace SharedKernel.Main.Infrastructure.Persistence.IMT.Repositories.ImtProvider
{
    public class ImtProviderRepository(ImtApplicationDbContext dbContext) 
        : GenericRepository<Provider, ImtApplicationDbContext>(dbContext), IImtProviderRepository
    {
    }
}
