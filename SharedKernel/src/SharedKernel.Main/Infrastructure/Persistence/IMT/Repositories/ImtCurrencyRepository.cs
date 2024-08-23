using SharedKernel.Main.Application.Interfaces.Repositories.IMT.Repositories;
using SharedKernel.Main.Domain.IMT.Entities;
using SharedKernel.Main.Infrastructure.Persistence.Notification.Configurations;
using SharedKernel.Main.Infrastructure.Services;


namespace SharedKernel.Main.Infrastructure.Persistence.IMT.Repositories
{
    public class ImtCurrencyRepository(ApplicationDbContext dbContext) : GenericRepository<Currency, ApplicationDbContext>(dbContext), IImtCurrencyRepository
    {
        public string? GetCurrencyCodeById(int imtSourceCurrencyId)
        {
            return _dbSet.Find(imtSourceCurrencyId)?.Code;
        }

        public int? GetCurrencyIdByCode(string currencyIsoCode)
        {
            return _dbSet.Where(c => c.IsoCode == currencyIsoCode)?.ToList()?.OrderBy(c => c.Id)?.LastOrDefault()?.Id;
        }
    }
}
