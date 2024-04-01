using SharedLibrary.Models;

namespace SharedLibrary.Interfaces.Repositories
{
    public interface ICountryRepository : IGenericRepository<Country>
    {
        public string CountryToIso(string code, bool getCountryCode, string countryIsoCode);
    }
}
