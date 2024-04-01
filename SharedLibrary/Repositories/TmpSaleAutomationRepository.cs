using SharedLibrary.Interfaces;
using SharedLibrary.Interfaces.Repositories;
using SharedLibrary.Models;

namespace SharedLibrary.Repositories;

public class TmpSaleAutomationRepository : GenericRepository<TmpSaleAutomation>, ITmpSaleAutomationRepository
{
    public TmpSaleAutomationRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
}