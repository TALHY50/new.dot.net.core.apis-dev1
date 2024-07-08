using SharedLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMT.Application.Domain.Ports.Repositories.ImtMoneyTransfer
{
    public interface IImtMoneyTransferRepository : IGenericRepository<SharedLibrary.Models.IMT.ImtMoneyTransfer>
    {
    }
}
