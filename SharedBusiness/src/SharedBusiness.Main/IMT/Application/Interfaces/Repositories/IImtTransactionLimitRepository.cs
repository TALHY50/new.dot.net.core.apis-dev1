using SharedBusiness.Main.IMT.Domain.Entities;

namespace SharedBusiness.Main.IMT.Application.Interfaces.Repositories
{
    public interface IImtTransactionLimitRepository
    {
        TransactionLimit Create(TransactionLimit transactionLimit);
        TransactionLimit Edit(uint id,TransactionLimit transactionLimit);
        TransactionLimit FindById(uint id);
        List<TransactionLimit> All();
        bool DeleteById(uint id);
    }
}
