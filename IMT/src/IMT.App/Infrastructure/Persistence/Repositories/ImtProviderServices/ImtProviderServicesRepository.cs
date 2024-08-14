using IMT.App.Application.Ports.Repositories;
using SharedKernel.Main.Domain.IMT;
using SharedKernel.Main.Infrastructure.Persistence.Configurations;
using SharedKernel.Main.Infrastructure.Services;

namespace IMT.App.Infrastructure.Persistence.Repositories.ImtProviderServices
{
    public class ImtProviderServicesRepository(ApplicationDbContext dbContext)
        : GenericRepository<ProviderService, ApplicationDbContext> (dbContext), IImtProviderServicesRepository
    {
    }
}
