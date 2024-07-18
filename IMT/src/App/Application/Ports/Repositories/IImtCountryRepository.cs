using SharedKernel.Application.Interfaces;

namespace IMT.Application.Application.Ports.Repositories
{
    public interface IImtCountryRepository : IGenericRepository<SharedKernel.Domain.IMT.ImtCountry>
    {
        public string? GetCountryIsoCodeByCountryId(int imtSourceCountryId);
        public int? GetCountryIdByCountryIsoCode(string imtSourceCountryId);
    }
}
