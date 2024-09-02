using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;

namespace SharedBusiness.Main.Common.Infrastructure.Persistence.Repositories
{
    public class CorridorRepository(ApplicationDbContext dbContext) : EfRepository<Corridor>(dbContext), ICorridorRepository
    {
        //public Corridor? Add(Corridor corridor)
        //{
        //    dbContext.ImtCorridors.Add(corridor);
        //    dbContext.SaveChanges();
        //    dbContext.Entry(corridor).Reload();
        //    return corridor;
        //}

        //public bool Delete(Corridor corridor)
        //{
        //    dbContext.ImtCorridors.Remove(corridor);
        //    dbContext.SaveChanges();
        //    return true;
        //}

        //public Corridor? FindById(uint id)
        //{
        //    return dbContext.ImtCorridors.Find(id);
        //}

        //public List<Corridor> GetAll()
        //{
        //    return dbContext.ImtCorridors.ToList();
        //}

        //public Corridor? Update(Corridor corridor)
        //{
        //    dbContext.ImtCorridors.Update(corridor);
        //    dbContext.SaveChanges();
        //    dbContext.Entry(corridor).Reload();
        //    return corridor;
        //}
    }
}
