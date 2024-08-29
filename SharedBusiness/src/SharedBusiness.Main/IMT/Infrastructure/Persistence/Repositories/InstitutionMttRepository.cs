using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedBusiness.Main.IMT.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedBusiness.Main.IMT.Infrastructure.Persistence.Repositories
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
