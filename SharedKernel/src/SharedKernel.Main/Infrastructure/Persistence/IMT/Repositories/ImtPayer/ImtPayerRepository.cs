using SharedKernel.Main.Application.Interfaces.Repositories.IMT.Repositories;
using SharedKernel.Main.Domain.IMT.Entities;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Context;
using SharedKernel.Main.Infrastructure.Services;

namespace SharedKernel.Main.Infrastructure.Persistence.IMT.Repositories.ImtPayer
{
    public class ImtPayerRepository(ImtApplicationDbContext dbContext)
        : GenericRepository<Payer, ImtApplicationDbContext>(dbContext), IImtPayerRepository
    {
    }
}
