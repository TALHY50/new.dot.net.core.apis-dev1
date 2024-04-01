using SharedLibrary.Models;

namespace SharedLibrary.Interfaces.Repositories;

public interface ITransactionRepository : IGenericRepository<Transactionable>
{
    public Transactionable? UpdateTransaction(string transactionableType, int transactionableId,
        int transactionStateId,
        double? balance = null, string? moneyFlow = null);

    public Transactionable? GetByTransactionableTypeAndTransactionableId(string transactionableType,
        int transactionableId);


}