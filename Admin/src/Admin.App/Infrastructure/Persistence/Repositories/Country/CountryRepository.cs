using ADMIN.App.Application.Ports.Repositories.Country;
using ADMIN.Application.Infrastructure.Persistence.Configurations;
using SharedKernel.Main.Domain.IMT;
using SharedKernel.Main.Infrastructure.Services;

namespace ADMIN.App.Infrastructure.Persistence.Repositories.Country
{
    public class CountryRepository (ApplicationDbContext dbContext)
        : GenericRepository<SharedKernel.Main.Domain.IMT.Country, ApplicationDbContext> (dbContext),  ICountryRepository
    {
    }
}
