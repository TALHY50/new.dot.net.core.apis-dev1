
using SharedBusiness.Main.Common.Domain.Entities;

namespace SharedBusiness.Main.Common.Application.Services.Repositories
{
    public interface ICurrencyConversionRateRepository
    {
        CurrencyConversionRate? Add(CurrencyConversionRate currencyConversionRate);
        List<CurrencyConversionRate>? ViewAll();
        CurrencyConversionRate? View(uint id);
        bool Delete(CurrencyConversionRate currencyConversionRate);
        CurrencyConversionRate? Update(CurrencyConversionRate currencyConversionRate);
    }
}
