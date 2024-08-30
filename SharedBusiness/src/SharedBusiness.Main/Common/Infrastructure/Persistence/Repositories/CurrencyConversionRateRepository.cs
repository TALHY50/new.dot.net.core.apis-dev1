using Microsoft.EntityFrameworkCore;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedBusiness.Main.IMT.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedBusiness.Main.IMT.Infrastructure.Persistence.Repositories
{
    public class CurrencyConversionRateRepository(ApplicationDbContext dbContext) : IImtCurrencyConversionRateRepository
    {
        public CurrencyConversionRate? Add(CurrencyConversionRate currencyConversionRate)
        {
            dbContext.ImtCurrencyConversionRates.Add(currencyConversionRate);
            dbContext.SaveChanges();
            dbContext.Entry(currencyConversionRate).Reload();
            return currencyConversionRate;
        }

        public bool Delete(CurrencyConversionRate currencyConversionRate)
        {
            dbContext.ImtCurrencyConversionRates.Remove(currencyConversionRate);
            dbContext.SaveChanges();
            return true;
        }

        public CurrencyConversionRate? Update(CurrencyConversionRate currencyConversionRate)
        {
            dbContext.ImtCurrencyConversionRates.Update(currencyConversionRate);
            dbContext.SaveChanges();
            dbContext.Entry(currencyConversionRate).Reload();
            return currencyConversionRate;
        }

        public CurrencyConversionRate? View(uint id)
        {
            return dbContext.ImtCurrencyConversionRates.Find(id);
        }

        public List<CurrencyConversionRate>? ViewAll()
        {
            return dbContext.ImtCurrencyConversionRates.ToList();
        }
    }
}
