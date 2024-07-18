
using IMT.Application.Domain.Ports.Repositories.ImtTransaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedKernel.Infrastructure.Persistence.Configurations;
using SharedKernel.Infrastructure.Services;

namespace IMT.Application.Infrastructure.Persistence.Repositories.ImtTransaction
{
    public class ImtTransactionRepository(ApplicationDbContext dbContext):GenericRepository<SharedKernel.Domain.IMT.ImtTransaction,ApplicationDbContext>(dbContext),IImtTransactionRepository
    {
    }
}
