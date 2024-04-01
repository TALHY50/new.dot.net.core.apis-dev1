using SharedLibrary.Models;

namespace SharedLibrary.Interfaces.Repositories;

public interface ISaleRepository : IGenericRepository<Sale>
{
    public Sale? FindByOrderId(string orderId, uint? merchantId = null, string[]? selectedColumns = null,
        bool isFromOrderStatus = false);


    public Sale? FindById(int id);

    public Sale? FindByMerchantIdAndInvoiceId(int merchantId, string invoiceId);


    public List<Sale> GetByMerchantIdAndInvoiceId(uint merchantId, string invoiceId);

    public Sale? FindPendingByMerchantIdAndInvoiceId(uint merchantId, string invoiceId = "", int? saleType = 1,
        string? orderId = null);
}