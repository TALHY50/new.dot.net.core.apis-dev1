using IMT.App.Application.Ports.Repositories;
using SharedKernel.Main.Infrastructure.Persistence.Configurations;
using SharedKernel.Main.Infrastructure.Services;

namespace IMT.App.Infrastructure.Persistence.Repositories.ImtProviderService
{
    public class ImtProviderServiceRepository(ApplicationDbContext dbContext) : GenericRepository<SharedKernel.Main.Domain.IMT.ProviderService, ApplicationDbContext>(dbContext), IImtProviderServiceRepository
    {
    }
}
