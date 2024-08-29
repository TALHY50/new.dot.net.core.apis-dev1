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
    public class InstitutionRepository(ApplicationDbContext dbContext) : IInstitutionRepository
    {
        public Institution? Add(Institution entity)
        {
            dbContext.ImtInstitutions.Add(entity);
            dbContext.SaveChanges();
            dbContext.Entry(entity).ReloadAsync();
            return entity;
        }

        public bool Delete(uint id)
        {
            var entity = dbContext.ImtInstitutions.Find(id);
            if (entity != null)
            {
                dbContext.ImtInstitutions.Remove(entity);
                dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<Institution>? GetAll()
        {
           return dbContext.ImtInstitutions.ToList();
        }

        public Institution? Update(Institution entity)
        {
            dbContext.ImtInstitutions.Update(entity);
            dbContext.SaveChanges();
            dbContext.Entry(entity).ReloadAsync();
            return entity;
        }

        public Institution? View(uint id)
        {
            return dbContext.ImtInstitutions.Find(id);
        }
      
    }
}
