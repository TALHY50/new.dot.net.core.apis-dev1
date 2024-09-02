using SharedBusiness.Main.Common.Domain.Entities;

namespace SharedBusiness.Main.Common.Application.Services.Repositories
{
    public interface IPayerPaymentSpeedRepository
    {
        PayerPaymentSpeed? Add(PayerPaymentSpeed payerPaymentSpeed);
        List<PayerPaymentSpeed>? ViewAll();
        PayerPaymentSpeed? View(uint id);
        bool Delete(PayerPaymentSpeed payerPaymentSpeed);
        PayerPaymentSpeed? Update(PayerPaymentSpeed payerPaymentSpeed);
    }
}
