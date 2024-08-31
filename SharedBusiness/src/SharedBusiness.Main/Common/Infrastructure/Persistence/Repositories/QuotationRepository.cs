using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedKernel.Main.Infrastructure.Services;

namespace SharedBusiness.Main.Common.Infrastructure.Persistence.Repositories
{
    public class QuotationRepository(ApplicationDbContext dbContext) : GenericRepository<Quotation, ApplicationDbContext>(dbContext), IQuotationRepository
    {
        public Quotation? GetImtQuotationByInvoiceId(string invoiceId)
        {
            return _dbSet.Where(c=>c.OrderId == invoiceId)?.ToList()?.OrderBy(c=>c.Id)?.Last();
        }
    }
}
