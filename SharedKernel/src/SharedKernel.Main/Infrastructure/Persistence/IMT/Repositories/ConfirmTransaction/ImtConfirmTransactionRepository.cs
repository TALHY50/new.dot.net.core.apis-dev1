using SharedKernel.Main.Application.Interfaces.Repositories.IMT.Repositories;
using SharedKernel.Main.Domain.IMT.Entities;
using SharedKernel.Main.Infrastructure.Persistence.Notification.Configurations;
using SharedKernel.Main.Infrastructure.Services;

namespace SharedKernel.Main.Infrastructure.Persistence.IMT.Repositories.ConfirmTransaction
{
    public class ImtProviderErrorDetailsRepository(ApplicationDbContext dbContext) : GenericRepository<ProviderErrorDetail, ApplicationDbContext>(dbContext), IImtProviderErrorDetailsRepository
    {
    }
}
