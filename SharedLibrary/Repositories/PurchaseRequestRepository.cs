using SharedLibrary.Interfaces;
using SharedLibrary.Interfaces.Repositories;
using SharedLibrary.Models;

namespace SharedLibrary.Repositories
{
    public class PurchaseRequestRepository : GenericRepository<PurchaseRequest>, IPurchaseRequestRepository
    {
        const int SUCCESS = 1;
        const int MAXIMUM_ATTEMPTS = 20;

        public int application_code;

        private readonly IUnitOfWork _unitOfWork;
        public PurchaseRequestRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

     
        public PurchaseRequest? FindByMerchantIdInvoiceId(uint merchantId, string invoiceId, bool isFromOrderStatus = false)
        {
            var query = _unitOfWork.ApplicationDbContext.Requests.Where(s => s.InvoiceId == invoiceId);

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

        public PurchaseRequest? FindByOrderId(string orderId)
        {
            PurchaseRequest? purchaseRequest = UnitOfWork.ApplicationDbContext.Requests.FirstOrDefault(x => x.Ref == orderId);


            return purchaseRequest;
        }
    }
}
