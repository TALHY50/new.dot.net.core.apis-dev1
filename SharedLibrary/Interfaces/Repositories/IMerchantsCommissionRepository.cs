using SharedLibrary.Models;

namespace SharedLibrary.Interfaces.Repositories;

public interface IMerchantsCommissionRepository : IGenericRepository<MerchantsCommission>
{
    public MerchantsCommission? GetMCommissionByMIdPType(uint merchant_id, int payment_type_id, int currency_id);

    public MerchantPosCommission? GetMerchantPosCommissionByInstallment(int merchantId, int posId, int installment,
        bool isCommercialCard, string cardProgram, int currencyId);

}