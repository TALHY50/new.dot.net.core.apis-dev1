using SharedKernel.Main.Application.Interfaces.Repositories.Admin;
using SharedKernel.Main.Domain.IMT.Entities;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Context;
using SharedKernel.Main.Infrastructure.Services;

namespace SharedKernel.Main.Infrastructure.Persistence.Admin.Repositories
{
    public class ImtCorridorRepository(ImtApplicationDbContext dbContext) : GenericRepository<Corridor, ImtApplicationDbContext>(dbContext), IImtCorridorRepository
    {
    }
}
