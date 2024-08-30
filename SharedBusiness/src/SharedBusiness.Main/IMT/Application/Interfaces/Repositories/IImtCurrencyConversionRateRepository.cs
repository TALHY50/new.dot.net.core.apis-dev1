using SharedBusiness.Main.IMT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
