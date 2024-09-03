using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;
using SharedKernel.Main.Infrastructure.Persistence.Repositories;


namespace SharedBusiness.Main.Common.Infrastructure.Persistence.Repositories
{
    public class CountryRepository(ApplicationDbContext dbContext) : EfRepository<Country>(dbContext), ICountryRepository
    {
    }
}
