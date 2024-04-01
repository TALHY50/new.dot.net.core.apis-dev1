using SharedLibrary.Models;

namespace SharedLibrary.Interfaces.Repositories;

public interface IRollingBalanceRepository : IGenericRepository<RollingBalance>
{

    public RollingBalance? FindBySaleId(uint saleId);

}