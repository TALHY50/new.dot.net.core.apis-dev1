using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedBusiness.Main.IMT.Infrastructure.Persistence.Context;
using SharedKernel.Main.Infrastructure.Services;

namespace SharedBusiness.Main.IMT.Infrastructure.Persistence.Repositories
{
    public class ProviderRepository(ApplicationDbContext dbContext)
        : IImtProviderRepository
    {
        public Provider? Add(Provider provider)
        {
            dbContext.ImtProviders.Add(provider);
            dbContext.SaveChanges();
            dbContext.Entry(provider).Reload();
            return provider;
        }

        public bool Delete(Provider provider)
        {
            dbContext.ImtProviders.Remove(provider);
            dbContext.SaveChanges();
            return true;
        }

        public IEnumerable<Provider>? GetAll()
        {
            return dbContext.ImtProviders.ToList();
        }

        public Provider? Update(Provider provider)
        {
            dbContext.ImtProviders.Update(provider);
            dbContext.SaveChanges();
            dbContext.Entry(provider).Reload();
            return provider;
        }

        public Provider? View(uint id)
        {
            return dbContext.ImtProviders.Find(id);
        }
    }
}
