using IMT.App.Application.Interfaces.Repositories;
using IMT.App.Infrastructure.Persistence.Context;
using SharedKernel.Main.Infrastructure.Services;

namespace IMT.App.Infrastructure.Persistence.Repositories
{
    public class QuotationRepository(ApplicationDbContext dbContext) : GenericRepository<Domain.Entities.Quotation, ApplicationDbContext>(dbContext), IQuotationRepository
    {
        public Domain.Entities.Quotation? GetImtQuotationByInvoiceId(string invoiceId)
        {
            return _dbSet.Where(c=>c.OrderId == invoiceId)?.ToList()?.OrderBy(c=>c.Id)?.Last();
        }
    }
}
