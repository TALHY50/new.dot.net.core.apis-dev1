using IMT.App.Application.Ports.Repositories;
using SharedKernel.Main.Application.Interfaces;
using SharedKernel.Main.Infrastructure.Persistence.Configurations;
using SharedKernel.Main.Infrastructure.Services;

namespace IMT.App.Infrastructure.Persistence.Repositories.ImtProviders
{
    public class ImtProvidersRepository(ApplicationDbContext dbContext) : GenericRepository<SharedKernel.Main.Domain.IMT.Provider, ApplicationDbContext>(dbContext), IImtProvidersRepository
    {

    }
}
