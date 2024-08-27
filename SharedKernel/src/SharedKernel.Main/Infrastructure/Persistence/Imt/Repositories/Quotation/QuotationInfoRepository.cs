using SharedKernel.Main.Application.Interfaces.Repositories.IMT.Repositories;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Context;
using SharedKernel.Main.Infrastructure.Persistence.Notification.Configurations;
using SharedKernel.Main.Infrastructure.Services;

namespace SharedKernel.Main.Infrastructure.Persistence.Repositories.Quotation
{
    public class QuotationInfoRepository(ImtApplicationDbContext dbContext) : GenericRepository<SharedKernel.Main.Domain.IMT.Entities.QuotationInfo, ImtApplicationDbContext>(dbContext), IQuotationInfoRepository
    {
       
    }
}
