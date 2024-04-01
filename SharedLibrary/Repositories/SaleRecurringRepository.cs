using SharedLibrary.Interfaces;
using SharedLibrary.Interfaces.Repositories;
using SharedLibrary.Models;

namespace SharedLibrary.Repositories;

public class SaleRecurringRepository : GenericRepository<SaleRecurring>, ISaleRecurringRepository
{
    public SaleRecurringRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
}