using App.Application.Ports.Repositories;
using SharedKernel.Domain.IMT;
using SharedKernel.Infrastructure.Persistence.Configurations;
using SharedKernel.Infrastructure.Services;

namespace App.Infrastructure.Persistence.Repositories.ConfirmTransaction
{
    public class ImtProviderErrorDetailsRepository(ApplicationDbContext dbContext) : GenericRepository<ImtProviderErrorDetail, ApplicationDbContext>(dbContext), IImtProviderErrorDetailsRepository
    {
    }
}
