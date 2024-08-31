using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Infrastructure.Services;

namespace SharedBusiness.Main.IMT.Infrastructure.Persistence.Repositories;

public class MoneyTransferRepository(ApplicationDbContext dbContext):GenericRepository<MoneyTransfer,ApplicationDbContext>(dbContext),IMoneyTransferRepository
{

}