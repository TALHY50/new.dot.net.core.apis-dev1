using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Infrastructure.Persistence.Repositories;


namespace SharedBusiness.Main.Common.Infrastructure.Persistence.Repositories
{
    public class CurrencyConversionRateRepository(ApplicationDbContext dbContext) : EfRepository<CurrencyConversionRate>(dbContext), ICurrencyConversionRateRepository
    {
    }
}
