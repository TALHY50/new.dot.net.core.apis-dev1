using SharedBusiness.Main.Common.Domain.Entities;

namespace SharedBusiness.Main.Common.Application.Services.Repositories
{
    public interface IMTTPaymentSpeedRepository
    {
        MttPaymentSpeed? Add(MttPaymentSpeed mttPaymentSpeed);
        MttPaymentSpeed? Update(MttPaymentSpeed mttPaymentSpeed);
        bool Delete(MttPaymentSpeed mttPaymentSpeed);
        MttPaymentSpeed? View(uint id);
        IEnumerable<MttPaymentSpeed>? GetAll();
    }
}
