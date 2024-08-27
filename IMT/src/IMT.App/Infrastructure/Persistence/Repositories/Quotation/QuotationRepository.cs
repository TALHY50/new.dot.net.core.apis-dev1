using SharedKernel.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Context;
using SharedKernel.Main.Infrastructure.Services;

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
