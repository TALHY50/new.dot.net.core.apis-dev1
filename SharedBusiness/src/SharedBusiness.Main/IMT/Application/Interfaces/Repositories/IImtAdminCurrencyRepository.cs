using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Application.Common.Interfaces.Services;

namespace SharedBusiness.Main.IMT.Application.Interfaces.Repositories
{
    public interface IImtAdminCurrencyRepository
    {
        Currency? Add(Currency currency);
        Currency? Update(Currency currency);
        List<Currency> GetAll();
        bool Delete(Currency currency);
        Currency? FindById(uint id);
    }
}
