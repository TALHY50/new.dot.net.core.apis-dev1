using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;

namespace SharedBusiness.Main.Common.Infrastructure.Persistence.Repositories
{
    public class ProviderRepository(ApplicationDbContext dbContext)
        : IProviderRepository
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
