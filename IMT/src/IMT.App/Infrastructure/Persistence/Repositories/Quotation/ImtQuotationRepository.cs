using IMT.App.Application.Ports.Repositories;
using SharedKernel.Main.Domain.IMT;
using SharedKernel.Main.Infrastructure.Persistence.Configurations;
using SharedKernel.Main.Infrastructure.Services;

namespace IMT.App.Infrastructure.Persistence.Repositories.Quotation
{
    public class ImtQuotationRepository(ApplicationDbContext dbContext) : GenericRepository<SharedKernel.Main.Domain.IMT.Quotation, ApplicationDbContext>(dbContext), IImtQuotationRepository
    {
        public SharedKernel.Main.Domain.IMT.Quotation? GetImtQuotationByInvoiceId(string invoiceId)
        {
            return _dbSet.Where(c=>c.OrderId == invoiceId)?.ToList()?.OrderBy(c=>c.Id)?.Last();
        }
    }
}
