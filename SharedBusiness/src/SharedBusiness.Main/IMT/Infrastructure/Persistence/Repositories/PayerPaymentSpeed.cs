using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Infrastructure.Persistence.Context;

namespace SharedBusiness.Main.IMT.Infrastructure.Persistence.Repositories
{
    public class PayerPaymentSpeed(ApplicationDbContext dbContext) : IImtPayerPaymentSpeedRepository
    {
        public Domain.Entities.PayerPaymentSpeed? Add(Domain.Entities.PayerPaymentSpeed payerPaymentSpeed)
        {
            dbContext.ImtPayerPaymentSpeeds.Add(payerPaymentSpeed);
            dbContext.SaveChanges();
            dbContext.Entry(payerPaymentSpeed).Reload();
            return payerPaymentSpeed;
        }

        public bool Delete(Domain.Entities.PayerPaymentSpeed payerPaymentSpeed)
        {
            dbContext.ImtPayerPaymentSpeeds.Remove(payerPaymentSpeed);
            dbContext.SaveChanges();
            return true;
        }

        public Domain.Entities.PayerPaymentSpeed? Update(Domain.Entities.PayerPaymentSpeed payerPaymentSpeed)
        {
            dbContext.ImtPayerPaymentSpeeds.Update(payerPaymentSpeed);
            dbContext.SaveChanges();
            dbContext.Entry(payerPaymentSpeed).Reload();
            return payerPaymentSpeed;
        }

        public Domain.Entities.PayerPaymentSpeed? View(uint id)
        {
            return dbContext.ImtPayerPaymentSpeeds.Find(id);
        }

        public List<Domain.Entities.PayerPaymentSpeed>? ViewAll()
        {
            return dbContext.ImtPayerPaymentSpeeds.ToList();
        }
    }
}
