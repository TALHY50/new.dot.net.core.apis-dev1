using SharedLibrary.Interfaces;
using SharedLibrary.Interfaces.Repositories;
using SharedLibrary.Models;

namespace SharedLibrary.Repositories;

public class ArchivedRequestRepository : GenericRepository<ArchivedRequest>, IArchivedRequestRepository
{
    public ArchivedRequestRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        
        
        
    }
    
    
    public ArchivedRequest? FindByMerchantIdInvoiceId(uint merchantId, string invoiceId, bool isFromOrderStatus = false)
    {
        var query = UnitOfWork.ApplicationDbContext.ArchievedRequests.Where(s => s.InvoiceId == invoiceId);

        if (!isFromOrderStatus)
        {
            query.OrderByDescending(o => o.Id);
        }
        else
        {
            query.OrderByDescending(o => o.IsExpired)
                .ThenBy(o => o.IsDuplicateInvoice)
                .ThenBy(o => o.Id);
        }

        return query.FirstOrDefault();
    }
}