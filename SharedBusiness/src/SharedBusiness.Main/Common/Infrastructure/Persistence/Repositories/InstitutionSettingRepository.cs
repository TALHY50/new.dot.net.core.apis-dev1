using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;

namespace SharedBusiness.Main.Common.Infrastructure.Persistence.Repositories
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
