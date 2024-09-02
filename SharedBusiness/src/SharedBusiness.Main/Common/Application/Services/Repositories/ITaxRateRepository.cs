using SharedBusiness.Main.Common.Domain.Entities;

namespace SharedBusiness.Main.Common.Application.Services.Repositories
{
    public interface ITaxRateRepository
    {
        TaxRate? Add(TaxRate taxRate);
        List<TaxRate>? ViewAll();
        TaxRate? View(uint id);
        bool Delete(TaxRate taxRate);
        TaxRate? Update(TaxRate taxRate);
    }
}
