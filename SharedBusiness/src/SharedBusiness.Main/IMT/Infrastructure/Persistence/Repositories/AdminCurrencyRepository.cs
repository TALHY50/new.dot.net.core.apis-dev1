﻿using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedBusiness.Main.IMT.Infrastructure.Persistence.Context;
using SharedKernel.Main.Infrastructure.Services;

namespace SharedBusiness.Main.IMT.Infrastructure.Persistence.Repositories
{
    public class AdminCurrencyRepository(ApplicationDbContext dbContext) : IImtAdminCurrencyRepository
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
