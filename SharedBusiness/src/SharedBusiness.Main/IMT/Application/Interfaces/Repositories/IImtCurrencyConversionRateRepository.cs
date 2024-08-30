
using SharedBusiness.Main.Common.Domain.Entities;

namespace SharedBusiness.Main.IMT.Application.Interfaces.Repositories
{
    public interface IImtCurrencyConversionRateRepository
    {
        CurrencyConversionRate? Add(CurrencyConversionRate currencyConversionRate);
        List<CurrencyConversionRate>? ViewAll();
        CurrencyConversionRate? View(uint id);
        bool Delete(CurrencyConversionRate currencyConversionRate);
        CurrencyConversionRate? Update(CurrencyConversionRate currencyConversionRate);
    }
}
