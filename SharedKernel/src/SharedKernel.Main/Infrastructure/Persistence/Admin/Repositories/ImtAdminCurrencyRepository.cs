using SharedKernel.Main.Domain.IMT.Entities;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Context;
using SharedKernel.Main.Infrastructure.Services;
using SharedKernel.Main.Application.Interfaces.Repositories.Admin;

namespace SharedKernel.Main.Infrastructure.Persistence.Admin.Repositories
{
    public class ImtAdminCurrencyRepository(ImtApplicationDbContext dbContext) : GenericRepository<Currency, ImtApplicationDbContext>(dbContext), IImtAdminCurrencyRepository
    {
    }
}
