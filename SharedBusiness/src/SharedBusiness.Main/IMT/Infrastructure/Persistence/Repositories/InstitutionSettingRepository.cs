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
    public class InstitutionSettingRepository(ApplicationDbContext dbContext) : IInstitutionSettingRepository
    {
        public InstitutionAppSetting? Add(InstitutionAppSetting entity)
        {
            dbContext.ImtInstitutionAppSettings.Add(entity);
            dbContext.SaveChanges();
            dbContext.Entry(entity).ReloadAsync();
            return entity;
        }

        public bool Delete(uint id)
        {
            var entity = dbContext.ImtInstitutionAppSettings.Find(id);
            if (entity != null)
            {
                dbContext.ImtInstitutionAppSettings.Remove(entity);
                dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<InstitutionAppSetting>? GetAll()
        {
            return dbContext.ImtInstitutionAppSettings.ToList();
        }

        public InstitutionAppSetting? Update(InstitutionAppSetting entity)
        {
            dbContext.ImtInstitutionAppSettings.Update(entity);
            dbContext.SaveChanges();
            dbContext.Entry(entity).ReloadAsync();
            return entity;
        }

        public InstitutionAppSetting? View(uint id)
        {
            return dbContext.ImtInstitutionAppSettings.Find(id);
        }
    }
}
