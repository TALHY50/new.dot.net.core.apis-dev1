using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;

namespace SharedBusiness.Main.Common.Infrastructure.Persistence.Repositories
{
    public class ServiceMethodRepository(ApplicationDbContext dbContext) : IImtServiceMethodRepository
    {
        public ServiceMethod? Add(ServiceMethod serviceMethod)
        {
            dbContext.ImtServiceMethods.Add(serviceMethod);
            dbContext.SaveChanges();
            dbContext.Entry(serviceMethod).Reload();
            return serviceMethod;
        }

        public bool Delete(ServiceMethod serviceMethod)
        {
            dbContext.ImtServiceMethods.Remove(serviceMethod);
            dbContext.SaveChanges();
            return true;
        }

        public ServiceMethod? Update(ServiceMethod serviceMethod)
        {
            dbContext.ImtServiceMethods.Update(serviceMethod);
            dbContext.SaveChanges();
            dbContext.Entry(serviceMethod).Reload();
            return serviceMethod;
        }

        public ServiceMethod? View(uint id)
        {
            return dbContext.ImtServiceMethods.Find(id);
        }

        public List<ServiceMethod>? ViewAll()
        {
            return dbContext.ImtServiceMethods.ToList();
        }
    }
}
