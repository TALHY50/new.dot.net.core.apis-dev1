using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedBusiness.Main.IMT.Infrastructure.Persistence.Context;
using SharedKernel.Main.Infrastructure.Services;

namespace SharedBusiness.Main.IMT.Infrastructure.Persistence.Repositories
{
    public class MttRepository(ApplicationDbContext dbContext) : IImtMttsRepository
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
