using SharedKernel.Main.Admin.Application.Interfaces.Repositories;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Context;
using SharedKernel.Main.Infrastructure.Services;

namespace SharedKernel.Main.Infrastructure.Persistence.Imt.Repositories.Repositories
{
    public class PayerPaymentSpeed(ImtApplicationDbContext dbContext) : GenericRepository<Main.IMT.Domain.Entities.PayerPaymentSpeed, ImtApplicationDbContext> (dbContext) , IImtPayerPaymentSpeedRepository
    {

    }
}
