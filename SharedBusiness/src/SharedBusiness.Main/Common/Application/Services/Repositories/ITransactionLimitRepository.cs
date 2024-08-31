using SharedBusiness.Main.Common.Domain.Entities;

namespace SharedBusiness.Main.Common.Application.Services.Repositories
{
    public interface ITransactionLimitRepository
    {
        TransactionLimit Create(TransactionLimit transactionLimit);
        TransactionLimit Edit(uint id,TransactionLimit transactionLimit);
        TransactionLimit FindById(uint id);
        List<TransactionLimit> All();
        bool DeleteById(uint id);
    }
}
