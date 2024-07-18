using App.Application.Ports.Repositories;
using SharedKernel.Domain.IMT;
using SharedKernel.Infrastructure.Persistence.Configurations;
using SharedKernel.Infrastructure.Services;

namespace App.Infrastructure.Persistence.Repositories.Quotation
{
    public class ImtQuotationRepository(ApplicationDbContext dbContext) : GenericRepository<ImtQuotation, ApplicationDbContext>(dbContext), IImtQuotationRepository
    {
        public ImtQuotation? GetImtQuotationByInvoiceId(string invoiceId)
        {
            return _dbSet.Where(c=>c.OrderId == invoiceId)?.ToList()?.OrderBy(c=>c.Id)?.Last();
        }
    }
}
