using ADMIN.App.Application.Ports.Services.Interfaces.Country;
using ADMIN.App.Infrastructure.Persistence.Repositories.Country;
using ADMIN.Application.Infrastructure.Persistence.Configurations;

namespace ADMIN.App.Infrastructure.Persistence.Services.Country
{
    public class CountryService(ApplicationDbContext dbContext) 
        : CountryRepository(dbContext), ICountryService 
    {
    }
}
