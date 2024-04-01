using SharedLibrary.Interfaces;
using SharedLibrary.Interfaces.Repositories;
using SharedLibrary.Models;

namespace SharedLibrary.Repositories;

public class SaleRecurringHistoryRepository : GenericRepository<SaleRecurringHistory>, ISaleRecurringHistoryRepository
{
    public SaleRecurringHistoryRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
}