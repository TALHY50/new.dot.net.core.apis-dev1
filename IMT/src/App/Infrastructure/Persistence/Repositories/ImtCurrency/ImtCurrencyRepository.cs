using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMT.Application.Application.Ports.Repositories;
using SharedKernel.Infrastructure.Persistence.Configurations;
using SharedKernel.Infrastructure.Services;

namespace IMT.Application.Infrastructure.Persistence.Repositories.ImtCurrency
{
    public class ImtCurrencyRepository(ApplicationDbContext dbContext) : GenericRepository<SharedKernel.Domain.IMT.ImtCurrency, ApplicationDbContext>(dbContext), IImtCurrencyRepository
    {
        public string? GetCurrencyCodeById(int imtSourceCurrencyId)
        {
           return _dbSet.Find(imtSourceCurrencyId)?.Code;
        }

        public int? GetCurrencyIdByCode(string currencyIsoCode)
        {
             return _dbSet.Where(c=>c.IsoCode == currencyIsoCode)?.ToList()?.OrderBy(c=>c.Id)?.LastOrDefault()?.Id;
        }
    }
}
