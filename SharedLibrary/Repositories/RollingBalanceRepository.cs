using SharedLibrary.Interfaces;
using SharedLibrary.Interfaces.Repositories;
using SharedLibrary.Models;

namespace SharedLibrary.Repositories;

public class RollingBalanceRepository : GenericRepository<RollingBalance>, IRollingBalanceRepository
{
    public RollingBalanceRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public RollingBalance? FindBySaleId(uint saleId)
    {
        return UnitOfWork.ApplicationDbContext.RollingBalances.FirstOrDefault(x => x.SaleId == saleId);
    }
    
}