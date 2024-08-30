using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;

namespace SharedBusiness.Main.Common.Infrastructure.Persistence.Repositories
{
    public class ImtMttPaymentSpeedRepository(ApplicationDbContext dbContext)
        : IImtMttPaymentSpeedRepository
    {
        public MttPaymentSpeed? Add(MttPaymentSpeed mttPaymentSpeed)
        {
            dbContext.ImtMttPaymentSpeeds.Add(mttPaymentSpeed);
            dbContext.SaveChanges();
            dbContext.Entry(mttPaymentSpeed).Reload();
            return mttPaymentSpeed;
        }

        public bool Delete(MttPaymentSpeed mttPaymentSpeed)
        {
            dbContext.ImtMttPaymentSpeeds.Remove(mttPaymentSpeed);
            dbContext.SaveChanges();
            return true;
        }

        public IEnumerable<MttPaymentSpeed>? GetAll()
        {
            return dbContext.ImtMttPaymentSpeeds.ToList();
        }

        public MttPaymentSpeed? Update(MttPaymentSpeed mttPaymentSpeed)
        {
            dbContext.ImtMttPaymentSpeeds.Update(mttPaymentSpeed);
            dbContext.SaveChanges();
            dbContext.Entry(mttPaymentSpeed).Reload();
            return mttPaymentSpeed;
        }

        public MttPaymentSpeed? View(uint id)
        {
            return dbContext.ImtMttPaymentSpeeds.Find(id);
        }
    }
}
