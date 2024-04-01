using Microsoft.EntityFrameworkCore;
using SharedLibrary.Interfaces;
using SharedLibrary.Interfaces.Repositories;
using SharedLibrary.Models;

namespace SharedLibrary.Repositories;

public class RollingReserveRepository : GenericRepository<RollingReserve>, IRollingReserveRepository
{
    public RollingReserveRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<RollingReserve?> FindByMerchantIdAndCurrencyId(int merchantId, int currencyId)
    {
       return await UnitOfWork.ApplicationDbContext.RollingReserves.FirstOrDefaultAsync(x => x.MerchantId == merchantId
                                                                            && x.CurrencyId == currencyId);
    }
}