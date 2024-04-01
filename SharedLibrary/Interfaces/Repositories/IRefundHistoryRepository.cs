using SharedLibrary.Models;

namespace SharedLibrary.Interfaces.Repositories;

public interface IRefundHistoryRepository : IGenericRepository<RefundHistory>
{

    public RefundHistory FindByRefundTransactionIdAndMerchantId(string refundTransactionId, int merchantId);

    public RefundHistory? FindBySaleId(int saleId, int transactionStateId = TransactionState.PENDING);

}