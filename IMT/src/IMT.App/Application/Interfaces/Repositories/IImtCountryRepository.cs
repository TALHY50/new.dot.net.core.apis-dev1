using IMT.App.Domain.Entities;
using SharedKernel.Main.Application.Common.Interfaces.Services;

namespace IMT.App.Application.Interfaces.Repositories
{
    public interface IImtCountryRepository : IGenericRepository<Country>
    {
        public string? GetCountryIsoCodeByCountryId(int imtSourceCountryId);
        public int? GetCountryIdByCountryIsoCode(string imtSourceCountryId);
    }
}
