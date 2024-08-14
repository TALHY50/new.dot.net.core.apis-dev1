using IMT.App.Application.Ports.Repositories;
using SharedKernel.Main.Domain.IMT;
using SharedKernel.Main.Infrastructure.Persistence.Configurations;
using SharedKernel.Main.Infrastructure.Services;

namespace IMT.App.Infrastructure.Persistence.Repositories.ImtProviderPayers
{
    public class ImtProviderPayersRepository (ApplicationDbContext dbContext) : GenericRepository<ProviderPayer, ApplicationDbContext> (dbContext), IImtProviderPayersRepository
    {
    }
}
