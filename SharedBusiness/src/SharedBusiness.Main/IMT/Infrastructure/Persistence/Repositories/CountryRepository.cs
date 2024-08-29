using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedBusiness.Main.IMT.Infrastructure.Persistence.Context;
using SharedKernel.Main.Infrastructure.Services;

namespace SharedBusiness.Main.IMT.Infrastructure.Persistence.Repositories
{
    public class CountryRepository(ApplicationDbContext dbContext) : IAdminCountryRepository
    {
        public Country? Add(Country country)
        {
            dbContext.ImtCountries.Add(country);
            dbContext.SaveChanges();
            dbContext.Entry(country).Reload();
            return country;
        }

        public bool Delete(Country country)
        {
            dbContext.ImtCountries.Remove(country);
            dbContext.SaveChanges();
            return true;
        }

        public Country? Update(Country country)
        {
            dbContext.ImtCountries.Update(country);
            dbContext.SaveChanges();
            dbContext.Entry(country).Reload();
            return country;
        }

        public Country? View(uint id)
        {
            return dbContext.ImtCountries.Find(id);
        }

        public List<Country>? ViewAll()
        {
            return dbContext.ImtCountries.ToList();
        }
    }
}
