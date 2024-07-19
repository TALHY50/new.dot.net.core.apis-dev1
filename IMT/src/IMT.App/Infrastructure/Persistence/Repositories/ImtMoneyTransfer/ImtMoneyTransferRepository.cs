using App.Application.Ports.Repositories;
using SharedKernel.Main.Infrastructure.Persistence.Configurations;
using SharedKernel.Main.Infrastructure.Services;

namespace App.Infrastructure.Persistence.Repositories.ImtMoneyTransfer
{
    public class ImtMoneyTransferRepository(ApplicationDbContext dbContext): GenericRepository<SharedKernel.Main.Domain.IMT.ImtMoneyTransfer,ApplicationDbContext>(dbContext),IImtMoneyTransferRepository
    {
    }
}
