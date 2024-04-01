using SharedLibrary.Interfaces;
using SharedLibrary.Interfaces.Repositories;
using SharedLibrary.Models;

namespace SharedLibrary.Repositories;

public class SaleRecurringPaymentScheduleRepository : GenericRepository<SaleRecurringPaymentSchedule>, ISaleRecurringPaymentScheduleRepository
{
    public SaleRecurringPaymentScheduleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
}