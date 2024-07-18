using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedKernel.Application.Interfaces;

namespace IMT.Application.Domain.Ports.Repositories.ImtTransaction
{
    public interface IImtTransactionRepository : IGenericRepository<SharedKernel.Domain.IMT.ImtTransaction>
    {
    }
}
