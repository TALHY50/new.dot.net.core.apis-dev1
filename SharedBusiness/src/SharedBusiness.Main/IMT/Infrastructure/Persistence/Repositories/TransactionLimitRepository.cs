
using HtmlAgilityPack;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedBusiness.Main.IMT.Infrastructure.Persistence.Context;


namespace SharedBusiness.Main.IMT.Infrastructure.Persistence.Repositories
{
    public class TransactionLimitRepository(ApplicationDbContext dbContext) : IImtTransactionLimitRepository
    {

        public async Task<TransactionLimit> add(TransactionLimit transactionLimit)
        {
            try
            {
                IsCurrencyExist(transactionLimit.CurrencyId);
                await dbContext.AddAsync(transactionLimit);
                await dbContext.SaveChangesAsync();
                dbContext.Entry(transactionLimit).Reload();
                return await Task.FromResult(transactionLimit);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public Task<TransactionLimit> edit(uint id, TransactionLimit model)
        {
            try
            {
                var transactionLimit = dbContext.ImtTransactionLimits.Where(x => x.Id == id).FirstOrDefault();

                if (transactionLimit == null)
                {
                    throw new NodeNotFoundException("Data not found by the id");
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
                return Task.FromResult(transactionLimit);

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
