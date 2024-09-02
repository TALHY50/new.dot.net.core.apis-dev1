using SharedBusiness.Main.Common.Domain.Entities;

namespace SharedBusiness.Main.Common.Application.Services.Repositories
{
    public interface ITransactionTypeRepository
    {
        TransactionType? Add(TransactionType transactionType);
        TransactionType? Update(TransactionType transactionType);
        bool Delete(TransactionType transactionType);
        TransactionType? View(uint id);
        IEnumerable<TransactionType>? GetAll();
    }
}
