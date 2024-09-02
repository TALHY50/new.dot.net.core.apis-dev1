using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;

namespace SharedBusiness.Main.Common.Infrastructure.Persistence.Repositories
{
    public class AdminCurrencyRepository(ApplicationDbContext dbContext) : ICurrencyRepository
    {
        public Currency? Add(Currency currency)
        {
            dbContext.ImtCurrencies.Add(currency);
            dbContext.SaveChanges();
            dbContext.Entry(currency).Reload();
            return currency;
        }

        public bool Delete(Currency currency)
        {
            dbContext.ImtCurrencies.Remove(currency);
            dbContext.SaveChanges();
            return true;
        }

        public Currency? FindById(uint id)
        {
            return dbContext.ImtCurrencies.Find(id);
        }

        public List<Currency> GetAll()
        {
            return dbContext.ImtCurrencies.ToList();
        }

        public Currency? Update(Currency currency)
        {
            dbContext.ImtCurrencies.Update(currency);
            dbContext.SaveChanges();
            dbContext.Entry(currency).Reload();
            return currency;
        }
    }
}
