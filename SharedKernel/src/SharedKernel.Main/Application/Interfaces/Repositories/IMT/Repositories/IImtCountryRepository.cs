using SharedKernel.Main.Application.Common.Interfaces.Services;
using SharedKernel.Main.Domain.IMT.Entities;

namespace SharedKernel.Main.Application.Interfaces.Repositories.IMT.Repositories
{
    public interface IImtCountryRepository : IGenericRepository<Country>
    {
        public string? GetCountryIsoCodeByCountryId(int imtSourceCountryId);
        public int? GetCountryIdByCountryIsoCode(string imtSourceCountryId);
    }
}
