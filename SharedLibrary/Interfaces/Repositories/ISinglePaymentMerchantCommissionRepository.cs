using SharedLibrary.Models;

namespace SharedLibrary.Interfaces.Repositories;

public interface ISinglePaymentMerchantCommissionRepository : IGenericRepository<SinglePaymentMerchantCommission>
{
    public SinglePaymentMerchantCommission? CheckForSinglePaymentMerchantCommission(uint merchant_id, int currency_id,
        string card_type, string issuer_name);
}