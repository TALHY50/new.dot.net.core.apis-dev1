using IMT.App.Application.Ports.Repositories;
using SharedKernel.Main.Infrastructure.Persistence.Configurations;
using SharedKernel.Main.Infrastructure.Services;

namespace IMT.App.Infrastructure.Persistence.Repositories.ImtTransaction
{
    public class ImtTransactionRepository(ApplicationDbContext dbContext):GenericRepository<SharedKernel.Main.Domain.IMT.ImtTransaction,ApplicationDbContext>(dbContext),IImtTransactionRepository
    {
    }
}
