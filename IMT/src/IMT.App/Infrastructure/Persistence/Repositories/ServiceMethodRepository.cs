using IMT.App.Application.Interfaces.Repositories;
using IMT.App.Domain.Entities;
using IMT.App.Infrastructure.Persistence.Context;
using SharedKernel.Main.Infrastructure.Services;

namespace IMT.App.Infrastructure.Persistence.Repositories
{
    public class ServiceMethodRepository(ApplicationDbContext dbContext) : GenericRepository<ServiceMethod, ApplicationDbContext>(dbContext), IImtServiceMethodRepository
    {
    }
}
