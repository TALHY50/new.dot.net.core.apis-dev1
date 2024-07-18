using IMT.Application.Application.Ports.Repositories;
using SharedKernel.Domain.IMT;
using SharedKernel.Infrastructure.Persistence.Configurations;
using SharedKernel.Infrastructure.Services;

namespace IMT.Application.Domain.Ports.Repositories.ConfirmTransaction
{
    public class ImtProviderErrorDetailsRepository(ApplicationDbContext dbContext) : GenericRepository<ImtProviderErrorDetail, ApplicationDbContext>(dbContext), IImtProviderErrorDetailsRepository
    {
    }
}
