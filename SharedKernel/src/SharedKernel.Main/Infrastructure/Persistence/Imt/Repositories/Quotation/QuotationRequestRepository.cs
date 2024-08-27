using SharedKernel.Main.Application.Interfaces.Repositories.IMT.Repositories;
using SharedKernel.Main.Domain.IMT.Entities;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Context;
using SharedKernel.Main.Infrastructure.Persistence.Notification.Configurations;
using SharedKernel.Main.Infrastructure.Services;

namespace SharedKernel.Main.Infrastructure.Persistence.Repositories.Quotation
{
    public class QuotationRequestRepository(ImtApplicationDbContext dbContext) : GenericRepository<QuotationRequest, ImtApplicationDbContext>(dbContext),IQuotationRequestRepository
    {
       
    }
}
