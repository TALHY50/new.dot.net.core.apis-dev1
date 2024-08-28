using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedBusiness.Main.IMT.Infrastructure.Persistence.Context;
using SharedKernel.Main.Infrastructure.Services;

namespace SharedBusiness.Main.IMT.Infrastructure.Persistence.Repositories
{
    public class ProviderRepository(ApplicationDbContext dbContext) 
        : GenericRepository<Provider, ApplicationDbContext>(dbContext), IImtProviderRepository
    {
    }
}
