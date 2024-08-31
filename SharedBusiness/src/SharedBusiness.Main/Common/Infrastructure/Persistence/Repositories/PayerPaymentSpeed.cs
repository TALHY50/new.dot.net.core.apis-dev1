using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;

namespace SharedBusiness.Main.Common.Infrastructure.Persistence.Repositories
{
    public class PayerPaymentSpeed(ApplicationDbContext dbContext) : IPayerPaymentSpeedRepository
    {
        public Common.Domain.Entities.PayerPaymentSpeed? Add(Common.Domain.Entities.PayerPaymentSpeed payerPaymentSpeed)
        {
            dbContext.ImtPayerPaymentSpeeds.Add(payerPaymentSpeed);
            dbContext.SaveChanges();
            dbContext.Entry(payerPaymentSpeed).Reload();
            return payerPaymentSpeed;
        }

        public bool Delete(Common.Domain.Entities.PayerPaymentSpeed payerPaymentSpeed)
        {
            dbContext.ImtPayerPaymentSpeeds.Remove(payerPaymentSpeed);
            dbContext.SaveChanges();
            return true;
        }

        public Common.Domain.Entities.PayerPaymentSpeed? Update(Common.Domain.Entities.PayerPaymentSpeed payerPaymentSpeed)
        {
            dbContext.ImtPayerPaymentSpeeds.Update(payerPaymentSpeed);
            dbContext.SaveChanges();
            dbContext.Entry(payerPaymentSpeed).Reload();
            return payerPaymentSpeed;
        }

        public Common.Domain.Entities.PayerPaymentSpeed? View(uint id)
        {
            return dbContext.ImtPayerPaymentSpeeds.Find(id);
        }

        public List<Common.Domain.Entities.PayerPaymentSpeed>? ViewAll()
        {
            return dbContext.ImtPayerPaymentSpeeds.ToList();
        }
    }
}
