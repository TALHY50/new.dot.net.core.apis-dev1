using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;

namespace SharedBusiness.Main.Common.Infrastructure.Persistence.Repositories
{
    public class MttRepository(ApplicationDbContext dbContext) : IMTTRepository
    {
        public Mtt? Add(Mtt entity)
        {
            dbContext.ImtMtts.Add(entity);
            dbContext.SaveChanges();
            dbContext.Entry(entity).ReloadAsync();
            return entity;
        }

        public bool Delete(uint id)
        {
            var entity = dbContext.ImtMtts.Find(id);
            if (entity != null)
            {
                dbContext.ImtMtts.Remove(entity);
                dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<Mtt>? GetAll()
        {
            return dbContext.ImtMtts.ToList();
        }

        public Mtt? Update(Mtt entity)
        {
            dbContext.ImtMtts.Update(entity);
            dbContext.SaveChanges();
            dbContext.Entry(entity).ReloadAsync();
            return entity;
        }

        public Mtt? View(uint id)
        {
            return dbContext.ImtMtts.Find(id);
        }
    }
}
