using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;

namespace SharedBusiness.Main.Common.Infrastructure.Persistence.Repositories
{
    public class TransactionTypeRepository(ApplicationDbContext dbContext)
        : IImtTransactionTypeRepository
    {
        public TransactionType? Add(TransactionType transactionType)
        {
            dbContext.ImtTransactionTypes.Add(transactionType);
            dbContext.SaveChanges();
            dbContext.Entry(transactionType).Reload();
            return transactionType;
        }

        public bool Delete(TransactionType transactionType)
        {
            dbContext.ImtTransactionTypes.Remove(transactionType);
            dbContext.SaveChanges();
            return true;
        }

        public IEnumerable<TransactionType>? GetAll()
        {
            return dbContext.ImtTransactionTypes.ToList();
        }

        public TransactionType? Update(TransactionType transactionType)
        {
            dbContext.ImtTransactionTypes.Update(transactionType);
            dbContext.SaveChanges();
            dbContext.Entry(transactionType).Reload();
            return transactionType;
        }

        public TransactionType? View(uint id)
        {
            return dbContext.ImtTransactionTypes.Find(id);
        }
    }
}
