
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;



namespace SharedBusiness.Main.IMT.Infrastructure.Persistence.Repositories
{
    public class TransactionLimitRepository(ApplicationDbContext dbContext) : ITransactionLimitRepository
    {

        public List<TransactionLimit> All()
        {
            try
            {
                return dbContext.ImtTransactionLimits.ToList();
            }
            catch (Exception ex) {
                throw;
            }
        }

        public TransactionLimit Create(TransactionLimit transactionLimit)
        {
            try
            {
                IsCurrencyExist(transactionLimit.CurrencyId);
                dbContext.AddAsync(transactionLimit);
                dbContext.SaveChangesAsync();
                dbContext.Entry(transactionLimit).Reload();
                return transactionLimit;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        

        public TransactionLimit Edit(uint id, TransactionLimit model)
        {
            try
            {
                var transactionLimit = FindById(id);

                if (transactionLimit == null)
                {
                    throw new InvalidOperationException("Data not found by the id");
                }

                transactionLimit.TransactionType = model.TransactionType;
                transactionLimit.DailyTotalNumber = model.DailyTotalNumber;
                transactionLimit.CurrencyId = model.CurrencyId;
                transactionLimit.UserCategory = model.UserCategory;
                transactionLimit.DailyTotalAmount = model.DailyTotalAmount;
                transactionLimit.MonthlyTotalNumber = model.MonthlyTotalNumber;
                transactionLimit.MonthlyTotalAmount = model.MonthlyTotalAmount;

                IsCurrencyExist(model.CurrencyId);
                dbContext.ImtTransactionLimits.Update(transactionLimit);
                dbContext.SaveChanges();
                dbContext.Entry(transactionLimit).Reload();
                return transactionLimit;

            }
            catch (Exception ex)
            {
                throw;

            }
        }

        public TransactionLimit FindById(uint id)
        {
            try
            {
                var transactionLimit = dbContext.ImtTransactionLimits.Where(x => x.Id == id).FirstOrDefault();
                if (transactionLimit == null)
                {
                    throw new InvalidOperationException("Data not found by the id");
                }
                return transactionLimit;
            }
            catch (Exception ex) { 
                     throw;
            }
        }

        public bool DeleteById(uint id)
        {
            try
            {
                bool returnData = true;
                var transactionLimit = dbContext.ImtTransactionLimits.Where(x => x.Id == id).FirstOrDefault();
                if (transactionLimit == null)
                {
                    throw new InvalidOperationException("Data not found by the id");
                }
                dbContext.ImtTransactionLimits.Remove(transactionLimit);
                dbContext.SaveChanges();
                return returnData;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool IsCurrencyExist(uint? currencyId)
        {

            var currencyExist = dbContext.ImtCurrencies.Any(x => x.Id == currencyId);
            if (!currencyExist)
            {
                throw new InvalidOperationException("Currency Not Found");
            }
            return currencyExist;
        }
    }
}
