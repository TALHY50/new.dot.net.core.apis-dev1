using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedBusiness.Main.IMT.Infrastructure.Persistence.Context;
using SharedKernel.Main.Infrastructure.Services;

namespace SharedBusiness.Main.IMT.Infrastructure.Persistence.Repositories
{
    public class InstitutionFundRepository(ApplicationDbContext dbContext) : IImtInstitutionFundRepository
    {
        public InstitutionFund? Add(InstitutionFund institutionFund)
        {
            dbContext.ImtInstitutionFunds.Add(institutionFund);
            dbContext.SaveChanges();
            dbContext.Entry(institutionFund).Reload();
            return institutionFund;
        }

        public bool Delete(InstitutionFund institutionFund)
        {
            dbContext.ImtInstitutionFunds.Remove(institutionFund);
            dbContext.SaveChanges();
            return true;
        }

        public InstitutionFund? Update(InstitutionFund institutionFund)
        {
            dbContext.ImtInstitutionFunds.Update(institutionFund);
            dbContext.SaveChanges();
            dbContext.Entry(institutionFund).Reload();
            return institutionFund;
        }

        public InstitutionFund? View(uint id)
        {
            return dbContext.ImtInstitutionFunds.Find(id);
        }

        public List<InstitutionFund>? ViewAll()
        {
            return dbContext.ImtInstitutionFunds.ToList();
        }
    }
}
