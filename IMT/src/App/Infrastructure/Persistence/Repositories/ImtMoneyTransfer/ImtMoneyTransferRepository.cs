using App.Application.Ports.Repositories;
using SharedKernel.Infrastructure.Persistence.Configurations;
using SharedKernel.Infrastructure.Services;

namespace App.Infrastructure.Persistence.Repositories.ImtMoneyTransfer
{
    public class ImtMoneyTransferRepository(ApplicationDbContext dbContext): GenericRepository<SharedKernel.Domain.IMT.ImtMoneyTransfer,ApplicationDbContext>(dbContext),IImtMoneyTransferRepository
    {
    }
}
