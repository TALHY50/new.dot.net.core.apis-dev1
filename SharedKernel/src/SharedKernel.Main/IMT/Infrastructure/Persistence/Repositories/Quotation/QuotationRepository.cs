using SharedKernel.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Infrastructure.Services;
using SharedKernel.Main.Notification.Infrastructure.Persistence.Configurations;

namespace SharedKernel.Main.Infrastructure.Persistence.Repositories.Quotation
{
    public class QuotationRepository(ApplicationDbContext dbContext) : GenericRepository<Main.IMT.Domain.Entities.Quotation, ApplicationDbContext>(dbContext), IQuotationRepository
    {
        public Main.IMT.Domain.Entities.Quotation? GetImtQuotationByInvoiceId(string invoiceId)
        {
            return _dbSet.Where(c=>c.OrderId == invoiceId)?.ToList()?.OrderBy(c=>c.Id)?.Last();
        }
    }
}
