using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;

namespace SharedBusiness.Main.Common.Infrastructure.Persistence.Repositories
{
    public class InstitutionMttRepository(ApplicationDbContext dbContext) : IImtInstitutionMttRepository
    {
        public InstitutionMtt? Add(InstitutionMtt institutionMtt)
        {
            dbContext.ImtInstitutionMtts.Add(institutionMtt);
            dbContext.SaveChanges();
            dbContext.Entry(institutionMtt).Reload();
            return institutionMtt;
        }

        public bool Delete(InstitutionMtt institutionMtt)
        {
            dbContext.ImtInstitutionMtts.Remove(institutionMtt);
            dbContext.SaveChanges();
            return true;
        }

        public InstitutionMtt? FindById(uint id)
        {
            return dbContext.ImtInstitutionMtts.Find(id);
        }

        public List<InstitutionMtt> GetAll()
        {
            return dbContext.ImtInstitutionMtts.ToList();
        }

        public InstitutionMtt? Update(InstitutionMtt institutionMtt)
        {
            dbContext.ImtInstitutionMtts.Update(institutionMtt);
            dbContext.SaveChanges();
            dbContext.Entry(institutionMtt).Reload();
            return institutionMtt;
        }
    }
}
