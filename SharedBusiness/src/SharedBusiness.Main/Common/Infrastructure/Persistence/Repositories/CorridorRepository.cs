using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;

namespace SharedBusiness.Main.Common.Infrastructure.Persistence.Repositories
{
    public class CorridorRepository(ApplicationDbContext dbContext) : EfRepository<Corridor>(dbContext), ICorridorRepository
    {
    }
}
