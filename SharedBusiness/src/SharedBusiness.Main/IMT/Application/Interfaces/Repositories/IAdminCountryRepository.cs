using SharedBusiness.Main.IMT.Domain.Entities;
using SharedKernel.Main.Application.Common.Interfaces.Services;

namespace SharedBusiness.Main.IMT.Application.Interfaces.Repositories
{
    public interface IAdminCountryRepository
    {
        Country? Add(Country country);
        List<Country>? ViewAll();
        Country? View(uint id);
        bool Delete(Country country);
        Country? Update(Country country);
    }
}
