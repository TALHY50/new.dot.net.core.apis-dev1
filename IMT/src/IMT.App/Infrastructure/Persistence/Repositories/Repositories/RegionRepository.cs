using SharedKernel.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.IMT.Domain.Entities;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Context;
using SharedKernel.Main.Infrastructure.Services;

namespace SharedKernel.Main.Infrastructure.Persistence.Imt.Repositories.Repositories
{
    public class RegionRepository(ApplicationDbContext dbContext) 
        : GenericRepository<Region, ApplicationDbContext>(dbContext), IImtRegionRepository
    {
    }
}
