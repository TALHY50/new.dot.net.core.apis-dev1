using SharedKernel.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Context;
using SharedKernel.Main.Infrastructure.Services;

namespace SharedKernel.Main.Infrastructure.Persistence.Imt.Repositories.Repositories
{
    public class PayerPaymentSpeed(ApplicationDbContext dbContext) : GenericRepository<Main.IMT.Domain.Entities.PayerPaymentSpeed, ApplicationDbContext> (dbContext) , IImtPayerPaymentSpeedRepository
    {

    }
}
