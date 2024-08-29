using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedBusiness.Main.IMT.Infrastructure.Persistence.Context;
using SharedKernel.Main.Infrastructure.Services;

namespace SharedBusiness.Main.IMT.Infrastructure.Persistence.Repositories
{
    public class TaxRateRepository(ApplicationDbContext dbContext) : IImtTaxRateRepository
    {
        public TaxRate? Add(TaxRate taxRate)
        {
            dbContext.ImtTaxRates.Add(taxRate);
            dbContext.SaveChanges();
            dbContext.Entry(taxRate).Reload();
            return taxRate;
        }

        public bool Delete(TaxRate taxRate)
        {
            dbContext.ImtTaxRates.Remove(taxRate);
            dbContext.SaveChanges();
            return true;
        }

        public TaxRate? Update(TaxRate taxRate)
        {
            dbContext.ImtTaxRates.Update(taxRate);
            dbContext.SaveChanges();
            dbContext.Entry(taxRate).Reload();
            return taxRate;
        }

        public TaxRate? View(uint id)
        {
            return dbContext.ImtTaxRates.Find(id);
        }

        public List<TaxRate>? ViewAll()
        {
            return dbContext.ImtTaxRates.ToList();
        }
    }
}
