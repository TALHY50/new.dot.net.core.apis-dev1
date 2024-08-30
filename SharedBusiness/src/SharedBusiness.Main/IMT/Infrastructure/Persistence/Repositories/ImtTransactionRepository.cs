using Microsoft.EntityFrameworkCore;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedBusiness.Main.IMT.Infrastructure.Persistence.Context;
using SharedKernel.Main.Infrastructure.Services;

namespace SharedBusiness.Main.IMT.Infrastructure.Persistence.Repositories;

public class ImtTransactionRepository(ApplicationDbContext dbContext) : GenericRepository<Transaction,ApplicationDbContext>(dbContext),IImtTransactionRepository
{

}