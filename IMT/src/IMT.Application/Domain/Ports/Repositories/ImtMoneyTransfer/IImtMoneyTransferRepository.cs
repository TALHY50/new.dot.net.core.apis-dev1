using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedKernel.Application.Interfaces;

namespace IMT.Application.Domain.Ports.Repositories.ImtMoneyTransfer
{
    public interface IImtMoneyTransferRepository : IGenericRepository<SharedKernel.Domain.IMT.ImtMoneyTransfer>
    {
    }
}
