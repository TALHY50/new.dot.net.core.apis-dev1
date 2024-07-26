using SharedKernel.Main.Application.Interfaces;

namespace IMT.App.Application.Ports.Repositories
{
    public interface IImtCountryRepository : IGenericRepository<SharedKernel.Main.Domain.IMT.ImtCountry>
    {
        public string? GetCountryIsoCodeByCountryId(int imtSourceCountryId);
        public int? GetCountryIdByCountryIsoCode(string imtSourceCountryId);
    }
}
