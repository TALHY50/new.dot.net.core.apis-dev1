using IMT.App.Application.Ports.Repositories;
using SharedKernel.Main.Domain.IMT.Entities;
using SharedKernel.Main.Infrastructure.Persistence.Notification.Configurations;
using SharedKernel.Main.Infrastructure.Services;

namespace IMT.App.Infrastructure.Persistence.Repositories.ImtCurrency
{
    public class ImtCurrencyRepository(ApplicationDbContext dbContext) : GenericRepository<Currency, ApplicationDbContext>(dbContext), IImtCurrencyRepository
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
