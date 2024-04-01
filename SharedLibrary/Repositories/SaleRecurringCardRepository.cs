using SharedLibrary.Interfaces;
using SharedLibrary.Interfaces.Repositories;
using SharedLibrary.Models;

namespace SharedLibrary.Repositories;

public class SaleRecurringCardRepository : GenericRepository<SaleRecurringCard>, ISaleRecurringCardRepository
{
    public SaleRecurringCardRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
}