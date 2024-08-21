using IMT.App.Application.Ports.Repositories;
using SharedKernel.Main.Infrastructure.Persistence;
using SharedKernel.Main.Infrastructure.Services;

namespace IMT.App.Infrastructure.Persistence.Repositories.ImtMoneyTransfer
{
    public class ImtMoneyTransferRepository(ApplicationDbContext dbContext): GenericRepository<SharedKernel.Main.Domain.IMT.MoneyTransfer,ApplicationDbContext>(dbContext),IImtMoneyTransferRepository
    {
    }
}
