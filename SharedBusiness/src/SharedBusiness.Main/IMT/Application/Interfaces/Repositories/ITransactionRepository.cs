using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedKernel.Main.Application.Common.Interfaces.Services;

namespace SharedBusiness.Main.IMT.Application.Interfaces.Repositories
{
    public interface ITransactionRepository : IGenericRepository<Transaction>
    {
    }
}
