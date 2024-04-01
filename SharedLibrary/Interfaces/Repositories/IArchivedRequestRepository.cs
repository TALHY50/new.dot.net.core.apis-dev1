using SharedLibrary.Models;

namespace SharedLibrary.Interfaces.Repositories;

public interface IArchivedRequestRepository : IGenericRepository<ArchivedRequest>
{
    public ArchivedRequest? FindByMerchantIdInvoiceId(uint merchantId, string invoiceId,
        bool isFromOrderStatus = false);

}