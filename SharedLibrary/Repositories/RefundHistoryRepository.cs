using SharedLibrary.Interfaces;
using SharedLibrary.Interfaces.Repositories;
using SharedLibrary.Models;
using SharedLibrary.Utilities;

namespace SharedLibrary.Repositories;

public class RefundHistoryRepository : GenericRepository<RefundHistory>, IRefundHistoryRepository
{
    public RefundHistoryRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public RefundHistory FindByRefundTransactionIdAndMerchantId(string refundTransactionId, int merchantId)
    {
        var refundHistory = UnitOfWork.ApplicationDbContext.RefundHistories.FirstOrDefault(x =>
            x.MerchantId == merchantId && x.RefundTransactionId == refundTransactionId);

        return refundHistory;
    }

    public RefundHistory? FindBySaleId(int saleId, int transactionStateId = TransactionState.PENDING)
    {
        var q = UnitOfWork.ApplicationDbContext.RefundHistories.Where(x => x.SaleId == saleId);

        if (transactionStateId != null)
        {
            q = q.Where(x => x.TransactionStateId == transactionStateId);
        }
        
        var refundHistory = q.FirstOrDefault();

        return refundHistory;
    }
}