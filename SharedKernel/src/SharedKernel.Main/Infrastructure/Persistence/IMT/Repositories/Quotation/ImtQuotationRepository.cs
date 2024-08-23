using SharedKernel.Main.Application.Interfaces.Repositories.IMT.Repositories;
using SharedKernel.Main.Infrastructure.Persistence.Notification.Configurations;
using SharedKernel.Main.Infrastructure.Services;

namespace SharedKernel.Main.Infrastructure.Persistence.Repositories.Quotation
{
    public class ImtQuotationRepository(ApplicationDbContext dbContext) : GenericRepository<SharedKernel.Main.Domain.IMT.Entities.Quotation, ApplicationDbContext>(dbContext), IImtQuotationRepository
    {
        public SharedKernel.Main.Domain.IMT.Entities.Quotation? GetImtQuotationByInvoiceId(string invoiceId)
        {
            return _dbSet.Where(c=>c.OrderId == invoiceId)?.ToList()?.OrderBy(c=>c.Id)?.Last();
        }
    }
}
