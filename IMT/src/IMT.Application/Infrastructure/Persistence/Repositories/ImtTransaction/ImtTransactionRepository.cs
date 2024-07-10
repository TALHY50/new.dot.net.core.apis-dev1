
using IMT.Application.Domain.Ports.Repositories.ImtTransaction;
using SharedLibrary.Persistence.Configurations;
using SharedLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMT.Application.Infrastructure.Persistence.Repositories.ImtTransaction
{
    public class ImtTransactionRepository(ApplicationDbContext dbContext):GenericRepository<SharedLibrary.Models.IMT.ImtTransaction,ApplicationDbContext>(dbContext),IImtTransactionRepository
    {
    }
}
