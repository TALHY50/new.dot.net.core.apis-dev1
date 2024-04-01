using SharedLibrary.Models;

namespace SharedLibrary.Interfaces.Repositories;

public interface IRollingReserveRepository : IGenericRepository<RollingReserve>
{
    public Task<RollingReserve?> FindByMerchantIdAndCurrencyId(int merchantId, int currencyId);
}