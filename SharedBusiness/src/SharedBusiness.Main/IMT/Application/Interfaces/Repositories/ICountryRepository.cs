using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Application.Common.Interfaces.Services;

namespace SharedBusiness.Main.IMT.Application.Interfaces.Repositories
{
    public interface ICountryRepository
    {
        Country? Add(Country country);
        List<Country>? GetAll();
        Country? GetById(uint id);
        bool Delete(Country country);
        Country? Update(Country country);
    }
}
