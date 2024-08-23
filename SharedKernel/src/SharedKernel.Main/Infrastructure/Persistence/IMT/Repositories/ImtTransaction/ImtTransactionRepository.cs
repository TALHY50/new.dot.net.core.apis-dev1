using SharedKernel.Main.Application.Interfaces.Repositories.IMT.Repositories;
using SharedKernel.Main.Domain.IMT.Entities;
using SharedKernel.Main.Infrastructure.Persistence.Notification.Configurations;
using SharedKernel.Main.Infrastructure.Services;

namespace SharedKernel.Main.Infrastructure.Persistence.Repositories.ImtTransaction
{
    public class ImtTransactionRepository(ApplicationDbContext dbContext):GenericRepository<Transaction,ApplicationDbContext>(dbContext),IImtTransactionRepository
    {
    }
}
