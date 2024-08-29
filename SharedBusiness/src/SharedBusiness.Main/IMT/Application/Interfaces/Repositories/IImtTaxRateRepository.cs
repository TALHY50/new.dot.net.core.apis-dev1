using SharedBusiness.Main.IMT.Domain.Entities;
using SharedKernel.Main.Application.Common.Interfaces.Services;

namespace SharedBusiness.Main.IMT.Application.Interfaces.Repositories
{
    public interface IImtTaxRateRepository
    {
        TaxRate? Add(TaxRate taxRate);
        List<TaxRate>? ViewAll();
        TaxRate? View(uint id);
        bool Delete(TaxRate taxRate);
        TaxRate? Update(TaxRate taxRate);
    }
}
