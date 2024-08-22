using IMT.App.Application.Ports.Repositories;
using SharedKernel.Main.Domain.IMT.Entities;
using SharedKernel.Main.Infrastructure.Persistence.Notification.Configurations;
using SharedKernel.Main.Infrastructure.Services;

namespace IMT.App.Infrastructure.Persistence.Repositories.ImtMoneyTransfer
{
    public class ImtMoneyTransferRepository(ApplicationDbContext dbContext): GenericRepository<MoneyTransfer,ApplicationDbContext>(dbContext),IImtMoneyTransferRepository
    {
    }
}
