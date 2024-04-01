using SharedLibrary.Models;

namespace SharedLibrary.Interfaces.Repositories;

public interface IPosRiskyCountryRepository : IGenericRepository<PosRiskyCountry>
{
    public List<PosRiskyCountry> GetRiskyCountries(Dictionary<string, object>? filters, string[]? columns = null);

    public PosRiskyCountry? CheckAndGetCommissionForRiskyCountryCard(
        int posId,
        string cardCountryCode,
        IEnumerable<PosRiskyCountry>? posRiskyCountriesCollection = null);
}