using SharedLibrary.Interfaces;
using SharedLibrary.Interfaces.Repositories;
using SharedLibrary.Models;

namespace SharedLibrary.Repositories
{
    public class TmpPaymentRecordRepository : GenericRepository<TmpPaymentRecord>, ITmpPaymentRecordRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public TmpPaymentRecordRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public TmpPaymentRecord? FindByOrderId(string order_id, int status = 0)
        {
            var query = _unitOfWork.ApplicationDbContext.TmpPaymentRecords.Where(s => s.OrderId == order_id);

            if (status == 2)
            {
                query = query.Where(s => s.Status != 2);
            }

            var result = query.FirstOrDefault();
            return result;
        }
        
        
        public TmpPaymentRecord? FindByMerchantIdAndInvoiceId(uint merchantId, string invoiceId)
        {
            var query = _unitOfWork.ApplicationDbContext.TmpPaymentRecords.Where(s => s.MerchantId == merchantId)
                .Where(s => s.InvoiceId == invoiceId);
            
            var tmpPaymentRecord = query.FirstOrDefault();
            return tmpPaymentRecord;
        }
        
        
        
        public TmpPaymentRecord? FindByMerchantKeyAndInvoiceId(string merchantKey, string invoiceId)
        {
            var query = _unitOfWork.ApplicationDbContext.TmpPaymentRecords.Where(s => s.MerchantKey == merchantKey)
                .Where(s => s.InvoiceId == invoiceId);
            
            var tmpPaymentRecord = query.FirstOrDefault();
            return tmpPaymentRecord;
        }

       
    }
}
