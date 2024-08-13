using IMT.App.Application.Ports.Repositories;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Main.Application.Interfaces;
using SharedKernel.Main.Infrastructure.Persistence.Configurations;
using SharedKernel.Main.Infrastructure.Services;

namespace IMT.App.Infrastructure.Persistence.Repositories.ImtProviderPayers
{
    public class ImtProviderPayersRepository (ApplicationDbContext dbContext) : GenericRepository<SharedKernel.Main.Domain.IMT.ProviderPayer, ApplicationDbContext> (dbContext), IImtProviderPayersRepository
    {
    }
}
