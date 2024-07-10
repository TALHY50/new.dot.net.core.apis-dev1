using SharedLibrary.Interfaces;
using SharedLibrary.Models.IMT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMT.Application.Domain.Ports.Repositories.ImtTransaction
{
    public interface IImtTransactionRepository : IGenericRepository<SharedLibrary.Models.IMT.ImtTransaction>
    {
    }
}
