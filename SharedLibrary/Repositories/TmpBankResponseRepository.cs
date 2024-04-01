using SharedLibrary.Interfaces;
using SharedLibrary.Interfaces.Repositories;
using SharedLibrary.Models;

namespace SharedLibrary.Repositories;

public class TmpBankResponseRepository : GenericRepository<TmpBankResponse>, ITmpBankResponseRepository
{
    public TmpBankResponseRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public TmpBankResponse? FindByOrderId(string orderId)
    {
        TmpBankResponse? tmpBankResponse =
            UnitOfWork.ApplicationDbContext.TmpBankResponses.FirstOrDefault(x => x.OrderId == orderId);

        return tmpBankResponse;
    }
}