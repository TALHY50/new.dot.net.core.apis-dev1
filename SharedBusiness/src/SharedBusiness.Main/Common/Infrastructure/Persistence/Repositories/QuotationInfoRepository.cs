using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedKernel.Main.Infrastructure.Services;

namespace SharedBusiness.Main.Common.Infrastructure.Persistence.Repositories
{
    public class QuotationInfoRepository(ApplicationDbContext dbContext) : EfRepository<QuotationInfo>(dbContext),IQuotationInfoRepository
    {
       
    }
}
