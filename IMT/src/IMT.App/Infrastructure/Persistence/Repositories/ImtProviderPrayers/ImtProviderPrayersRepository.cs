using IMT.App.Application.Ports.Repositories;
using SharedKernel.Main.Infrastructure.Persistence.Configurations;
using SharedKernel.Main.Infrastructure.Services;

namespace IMT.App.Infrastructure.Persistence.Repositories.ImtProviderPrayers
{
    public class ImtProviderPrayersRepository(ApplicationDbContext dbContext) : GenericRepository<SharedKernel.Main.Domain.IMT.ProviderPayer, ApplicationDbContext>(dbContext), IImtProviderPrayersRepository
    {
    }
}
