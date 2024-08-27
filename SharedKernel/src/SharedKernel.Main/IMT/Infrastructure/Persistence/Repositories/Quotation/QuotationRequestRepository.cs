using SharedKernel.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.IMT.Domain.Entities;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Context;
using SharedKernel.Main.Infrastructure.Services;

namespace SharedKernel.Main.Infrastructure.Persistence.Repositories.Quotation
{
    public class QuotationRequestRepository(ImtApplicationDbContext dbContext) : GenericRepository<QuotationRequest, ImtApplicationDbContext>(dbContext),IQuotationRequestRepository
    {
       
    }
}
