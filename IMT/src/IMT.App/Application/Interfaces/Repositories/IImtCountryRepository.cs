using SharedKernel.Main.Application.Common.Interfaces.Services;
using SharedKernel.Main.IMT.Domain.Entities;

namespace SharedKernel.Main.IMT.Application.Interfaces.Repositories
{
    public interface IImtCountryRepository : IGenericRepository<Country>
    {
        public string? GetCountryIsoCodeByCountryId(int imtSourceCountryId);
        public int? GetCountryIdByCountryIsoCode(string imtSourceCountryId);
    }
}
