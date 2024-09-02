using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;

namespace SharedBusiness.Main.Common.Infrastructure.Persistence.Repositories
{
    public class MTTPaymentSpeedRepository(ApplicationDbContext dbContext)
        : IMTTPaymentSpeedRepository
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
