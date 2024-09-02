using SharedBusiness.Main.Common.Domain.Entities;

namespace SharedBusiness.Main.Common.Application.Services.Repositories
{
    public interface ICurrencyRepository
    {
        Currency? Add(Currency currency);
        Currency? Update(Currency currency);
        List<Currency> GetAll();
        bool Delete(Currency currency);
        Currency? FindById(uint id);
    }
}
