using SharedBusiness.Main.IMT.Domain.Entities;

namespace SharedBusiness.Main.IMT.Application.Interfaces.Repositories
{
    public interface IImtPayerPaymentSpeedRepository
    {
        PayerPaymentSpeed? Add(PayerPaymentSpeed payerPaymentSpeed);
        List<PayerPaymentSpeed>? ViewAll();
        PayerPaymentSpeed? View(uint id);
        bool Delete(PayerPaymentSpeed payerPaymentSpeed);
        PayerPaymentSpeed? Update(PayerPaymentSpeed payerPaymentSpeed);
    }
}
