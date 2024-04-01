using SharedLibrary.Interfaces;
using SharedLibrary.Interfaces.Repositories;
using SharedLibrary.Models;

namespace SharedLibrary.Repositories
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        public CountryRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        public string CountryToIso(string code, bool getCountryCode, string countryIsoCode)
        {
            string countryCode;
            switch (countryIsoCode)
            {
                case "004":
                    countryCode = "AF";
                    break;
                case "008":
                    countryCode = "AL";
                    break;
                case "012":
                    countryCode = "DZ";
                    break;
                case "016":
                    countryCode = "AS";
                    break;
                case "020":
                    countryCode = "AD";
                    break;
                case "024":
                    countryCode = "AO";
                    break;
                case "792":
                    countryCode = "TR";
                    break;
                default:
                    countryCode = "660";
                    break;
            }
            return countryCode;
        }
    }
}
