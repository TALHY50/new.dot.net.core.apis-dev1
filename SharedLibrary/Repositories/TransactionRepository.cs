using SharedLibrary.Interfaces;
using SharedLibrary.Interfaces.Repositories;
using SharedLibrary.Models;

namespace SharedLibrary.Repositories;

public class TransactionRepository : GenericRepository<Transactionable>, ITransactionRepository
{
    public TransactionRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
    
    
    public Transactionable? UpdateTransaction(string transactionableType, int transactionableId, int transactionStateId,
        double? balance = null, string? moneyFlow = null)
    {

        var transaction = GetByTransactionableTypeAndTransactionableId(transactionableType, transactionableId);

        if (transaction != null)
        {
            if (balance != null)
            {
                transaction.Balance = balance;
            }
            
            
            if (moneyFlow != null)
            {
                transaction.MoneyFlow = moneyFlow;
            
            }
            
            Update(transaction);
        }
        
        return transaction;
        
    }

    public Transactionable? GetByTransactionableTypeAndTransactionableId(string transactionableType, int transactionableId)
    {
       
        var transactionable = UnitOfWork.ApplicationDbContext.Transactionables
            .Where(x => x.TransactionableType == transactionableType)
            .FirstOrDefault(x => x.TransactionableId == transactionableId);


        return transactionable;

    }

}