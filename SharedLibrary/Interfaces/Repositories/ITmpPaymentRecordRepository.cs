using SharedLibrary.Models;

namespace SharedLibrary.Interfaces.Repositories;

public interface ITmpPaymentRecordRepository : IGenericRepository<TmpPaymentRecord>
{
    public TmpPaymentRecord? FindByOrderId(string order_id, int status = 0);

    public TmpPaymentRecord? FindByMerchantIdAndInvoiceId(uint merchantId, string invoiceId);

    public TmpPaymentRecord? FindByMerchantKeyAndInvoiceId(string merchantKey, string invoiceId);
}