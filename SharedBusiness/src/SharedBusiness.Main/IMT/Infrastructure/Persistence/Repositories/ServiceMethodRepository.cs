using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedBusiness.Main.IMT.Infrastructure.Persistence.Context;
using SharedKernel.Main.Infrastructure.Services;

namespace SharedBusiness.Main.IMT.Infrastructure.Persistence.Repositories
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
