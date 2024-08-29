using SharedBusiness.Main.IMT.Domain.Entities;
using SharedKernel.Main.Application.Common.Interfaces.Services;

namespace SharedBusiness.Main.IMT.Application.Interfaces.Repositories
{
    public interface IImtTransactionLimitRepository
    {
        Task<TransactionLimit> add(TransactionLimit transactionLimit);
        Task<TransactionLimit> edit(uint id,TransactionLimit transactionLimit);
        Task<TransactionLimit> FindById(uint id);
    }
}
