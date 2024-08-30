using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;

namespace SharedBusiness.Main.Common.Infrastructure.Persistence.Repositories
{
    public class CountryRepository(ApplicationDbContext dbContext) : ICountryRepository
    {
        public Country? Add(Country country)
        {
            dbContext.Countries.Add(country);
            dbContext.SaveChanges();
            dbContext.Entry(country).Reload();
            return country;
        }

        public bool Delete(Country country)
        {
            dbContext.Countries.Remove(country);
            dbContext.SaveChanges();
            return true;
        }

        public Country? Update(Country country)
        {
            dbContext.Countries.Update(country);
            dbContext.SaveChanges();
            dbContext.Entry(country).Reload();
            return country;
        }

        public Country? GetById(uint id)
        {
            return dbContext.Countries.Find(id);
        }

        public List<Country>? GetAll()
        {
            return dbContext.Countries.ToList();
        }
    }
}
