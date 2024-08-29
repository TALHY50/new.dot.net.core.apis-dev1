using SharedBusiness.Main.IMT.Domain.Entities;

namespace SharedBusiness.Main.IMT.Application.Interfaces.Repositories
{
    public interface IImtTransactionLimitRepository
    {
        Task<TransactionLimit> Create(TransactionLimit transactionLimit);
        Task<TransactionLimit> Edit(uint id,TransactionLimit transactionLimit);
        Task<TransactionLimit> FindById(uint id);
        Task<List<TransactionLimit>> All();
        Task<bool> DeleteById(uint id);
    }
}
