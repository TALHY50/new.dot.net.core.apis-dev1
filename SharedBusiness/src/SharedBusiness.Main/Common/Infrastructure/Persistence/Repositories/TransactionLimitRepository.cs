
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;


namespace SharedBusiness.Main.Common.Infrastructure.Persistence.Repositories
{
    public class TransactionLimitRepository(ApplicationDbContext dbContext) : EfRepository<TransactionLimit>(dbContext), ITransactionLimitRepository 
    {
        public bool IsCurrencyExist(uint currencyId)
        {

            var currencyExist = dbContext.ImtCurrencies.Any(x => x.Id == currencyId);

            return currencyExist;
        }

        public bool IsTransactionTypeExist(sbyte transactionTypeId) {

            var transactionTypeExist = dbContext.ImtTransactionTypes.Any(x => x.Id == transactionTypeId);

            return transactionTypeExist;

        }


    }
}
