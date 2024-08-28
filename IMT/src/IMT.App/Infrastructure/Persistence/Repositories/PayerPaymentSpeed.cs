using IMT.App.Application.Interfaces.Repositories;
using IMT.App.Infrastructure.Persistence.Context;
using SharedKernel.Main.Infrastructure.Services;

namespace IMT.App.Infrastructure.Persistence.Repositories
{
    public class PayerPaymentSpeed(ApplicationDbContext dbContext) : GenericRepository<Domain.Entities.PayerPaymentSpeed, ApplicationDbContext> (dbContext) , IImtPayerPaymentSpeedRepository
    {

    }
}
