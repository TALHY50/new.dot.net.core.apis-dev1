using SharedBusiness.Main.IMT.Domain.Entities;
using SharedKernel.Main.Application.Common.Interfaces.Services;

namespace SharedBusiness.Main.IMT.Application.Interfaces.Repositories
{
    public interface IImtTransactionTypeRepository
    {
        TransactionType? Add(TransactionType transactionType);
        TransactionType? Update(TransactionType transactionType);
        bool Delete(TransactionType transactionType);
        TransactionType? View(uint id);
        IEnumerable<TransactionType>? GetAll();
    }
}
