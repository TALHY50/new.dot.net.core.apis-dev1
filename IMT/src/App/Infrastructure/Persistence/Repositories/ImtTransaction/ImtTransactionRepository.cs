using App.Application.Ports.Repositories;
using SharedKernel.Infrastructure.Persistence.Configurations;
using SharedKernel.Infrastructure.Services;

namespace App.Infrastructure.Persistence.Repositories.ImtTransaction
{
    public class ImtTransactionRepository(ApplicationDbContext dbContext):GenericRepository<SharedKernel.Domain.IMT.ImtTransaction,ApplicationDbContext>(dbContext),IImtTransactionRepository
    {
    }
}
