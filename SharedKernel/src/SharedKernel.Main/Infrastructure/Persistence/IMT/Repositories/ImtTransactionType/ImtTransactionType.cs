using SharedKernel.Main.Application.Interfaces.Repositories.IMT.Repositories;
using SharedKernel.Main.Domain.IMT.Entities;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Context;
using SharedKernel.Main.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Main.Infrastructure.Persistence.IMT.Repositories.ImtTransactionType
{
    public class ImtTransactionType(ImtApplicationDbContext dbContext) 
        : GenericRepository<TransactionType, ImtApplicationDbContext>(dbContext), IImtTransactionType
    {
    }
}
