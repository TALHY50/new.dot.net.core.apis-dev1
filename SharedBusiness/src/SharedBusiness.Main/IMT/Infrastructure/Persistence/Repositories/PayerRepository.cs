using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedBusiness.Main.IMT.Infrastructure.Persistence.Context;
using SharedKernel.Main.Infrastructure.Services;

namespace SharedBusiness.Main.IMT.Infrastructure.Persistence.Repositories
{
    public class PayerRepository(ApplicationDbContext dbContext) : IImtPayerRepository
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
