using App.Application.Ports.Repositories;
using SharedKernel.Main.Domain.IMT;
using SharedKernel.Main.Infrastructure.Persistence.Configurations;
using SharedKernel.Main.Infrastructure.Services;

namespace App.Infrastructure.Persistence.Repositories.ConfirmTransaction
{
    public class ImtProviderErrorDetailsRepository(ApplicationDbContext dbContext) : GenericRepository<ImtProviderErrorDetail, ApplicationDbContext>(dbContext), IImtProviderErrorDetailsRepository
    {
    }
}
