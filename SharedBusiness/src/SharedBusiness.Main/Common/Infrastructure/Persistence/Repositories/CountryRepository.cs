using Ardalis.Specification.EntityFrameworkCore;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;

namespace SharedBusiness.Main.Common.Infrastructure.Persistence.Repositories
{
    public class CountryRepository(ApplicationDbContext dbContext) : EfRepository<Country>(dbContext), ICountryRepository
    {
    }
}
