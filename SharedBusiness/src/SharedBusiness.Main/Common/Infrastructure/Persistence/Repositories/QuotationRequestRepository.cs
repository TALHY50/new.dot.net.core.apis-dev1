using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Infrastructure.Services;

namespace SharedBusiness.Main.Common.Infrastructure.Persistence.Repositories
{
    public class QuotationRequestRepository(ApplicationDbContext dbContext) : GenericRepository<QuotationRequest, ApplicationDbContext>(dbContext),IQuotationRequestRepository
    {
       
    }
}
