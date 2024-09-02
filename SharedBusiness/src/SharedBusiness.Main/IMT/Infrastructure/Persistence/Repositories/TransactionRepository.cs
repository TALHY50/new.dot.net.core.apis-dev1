using Microsoft.EntityFrameworkCore;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedKernel.Main.Infrastructure.Services;

namespace SharedBusiness.Main.IMT.Infrastructure.Persistence.Repositories;

public class TransactionRepository(ApplicationDbContext dbContext) : GenericRepository<Transaction,ApplicationDbContext>(dbContext),ITransactionRepository
{

}