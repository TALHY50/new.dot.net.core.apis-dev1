using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;

namespace SharedBusiness.Main.Common.Infrastructure.Persistence.Repositories
{
    public class PayerRepository(ApplicationDbContext dbContext) : IPayerRepository
    {
        public Payer? Add(Payer payer)
        {
            dbContext.ImtPayers.Add(payer);
            dbContext.SaveChanges();
            dbContext.Entry(payer).Reload();
            return payer;
        }

        public bool Delete(Payer payer)
        {
            dbContext.ImtPayers.Remove(payer);
            dbContext.SaveChanges();
            return true;
        }

        public Payer? FindById(uint id)
        {
            return dbContext.ImtPayers.Find(id);    
        }

        public List<Payer> GetAll()
        {
            return dbContext.ImtPayers.ToList();
        }

        public Payer? Update(Payer payer)
        {
            dbContext.ImtPayers.Update(payer);
            dbContext.SaveChanges();
            dbContext.Entry(payer).Reload();
            return payer;
        }
    }
}
