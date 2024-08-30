using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;

namespace SharedBusiness.Main.Common.Infrastructure.Persistence.Repositories
{
    public class RegionRepository(ApplicationDbContext dbContext)
        : IImtRegionRepository
    {
        public Region? Add(Region region)
        {
            dbContext.ImtRegions.Add(region);
            dbContext.SaveChanges();
            dbContext.Entry(region).Reload();
            return region;
        }

        public bool Delete(Region region)
        {
            dbContext.ImtRegions.Remove(region);
            dbContext.SaveChanges();
            return true;
        }

        public IEnumerable<Region>? GetAll()
        {
            return dbContext.ImtRegions.ToList();
        }

        public Region? Update(Region region)
        {
            dbContext.ImtRegions.Update(region);
            dbContext.SaveChanges();
            dbContext.Entry(region).Reload();
            return region;
        }

        public Region? View(uint id)
        {
            return dbContext.ImtRegions.Find(id);
        }
    }
}
