using SharedLibrary.Models;

namespace SharedLibrary.Interfaces.Repositories;

public interface IPurchaseRequestRepository : IGenericRepository<PurchaseRequest>
{
    public PurchaseRequest? FindByMerchantIdInvoiceId(uint merchantId, string invoiceId,
        bool isFromOrderStatus = false);
    
    public PurchaseRequest? FindByOrderId(string orderId);

}