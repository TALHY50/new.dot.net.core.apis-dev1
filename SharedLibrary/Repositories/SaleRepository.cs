using Microsoft.EntityFrameworkCore;
using SharedLibrary.Interfaces;
using SharedLibrary.Interfaces.Repositories;
using SharedLibrary.Models;

namespace SharedLibrary.Repositories
{
    public class SaleRepository : GenericRepository<Sale>, ISaleRepository
    {
        public SaleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public Sale? FindByOrderId(string orderId, uint? merchantId = null, string[]? selectedColumns = null, bool isFromOrderStatus = false)
        {
            var query = UnitOfWork.ApplicationDbContext.Sales
                .Where(s => s.OrderId == orderId);


            if (merchantId != null)
            {
                query = query.Where(x => x.MerchantId == merchantId);
            }

            if (selectedColumns != null)
            {
                //TODO
            }

            if (isFromOrderStatus)
            {
                query = query.OrderBy(x => x.Id).OrderBy(x => x.TransactionStateId);

            }
            else
            {
                query = query.OrderByDescending(x => x.CreatedAt);
            }

            return query.FirstOrDefault();
        }


        public Sale? FindById(int id)
        {
            return UnitOfWork.ApplicationDbContext.Sales.FirstOrDefault(x => x.Id == id);
        }
        
        public Sale? FindByMerchantIdAndInvoiceId(int merchantId, string invoiceId)
        {
            var sale = UnitOfWork.ApplicationDbContext.Sales
                .Where(x => x.MerchantId == merchantId && x.InvoiceId == invoiceId)
                .OrderBy(x => x.TransactionStateId)
                .ThenBy(x => x.IsDuplicateInvoice)
                .ThenBy(x => x.Id)
                .FirstOrDefault();

            return sale;
        }
        
        
        public Sale? FindPendingByMerchantIdAndInvoiceId(uint merchantId, string invoiceId = "", int? saleType = 1, string? orderId = null)
        {
            var queryable = UnitOfWork.ApplicationDbContext.Sales.AsQueryable();

            
            
            queryable = queryable.Where(x => x.MerchantId == merchantId  && x.TransactionStateId == TransactionState.PENDING);

            
            if (! string.IsNullOrEmpty(orderId))
            {
                queryable = queryable.Where(x => x.OrderId == orderId);
            }
            
            if (! string.IsNullOrEmpty(invoiceId))
            {
                queryable = queryable.Where(x => x.InvoiceId == invoiceId);
            }
            
            if (saleType != null)
            {
                queryable = queryable.Where(x => x.SaleType == saleType);
            }

           

            var sale = queryable.FirstOrDefault();    

            return sale;
        }
        
        
        public List<Sale> GetByMerchantIdAndInvoiceId(uint merchantId, string invoiceId)
        {
            var saleList = UnitOfWork.ApplicationDbContext.Sales
                .Where(x => x.MerchantId == merchantId && x.InvoiceId == invoiceId).ToList();

            return saleList;
        }
        
        
    }
}
