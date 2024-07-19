using App.Application.Ports.Repositories;
using SharedKernel.Main.Infrastructure.Persistence.Configurations;
using SharedKernel.Main.Infrastructure.Services;

namespace App.Infrastructure.Persistence.Repositories.ImtCurrency
{
    public class ImtCurrencyRepository(ApplicationDbContext dbContext) : GenericRepository<SharedKernel.Main.Domain.IMT.ImtCurrency, ApplicationDbContext>(dbContext), IImtCurrencyRepository
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
