using SharedLibrary.Interfaces;
using SharedLibrary.Interfaces.Repositories;
using SharedLibrary.Models;

namespace SharedLibrary.Repositories;

public class MerchantsCommissionRepository : GenericRepository<MerchantsCommission>, IMerchantsCommissionRepository
{
    public MerchantsCommissionRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public MerchantsCommission? GetMCommissionByMIdPType(uint merchant_id, int payment_type_id, int currency_id)
    {
        return UnitOfWork.ApplicationDbContext.MerchantsCommissions
                .Where(mc => mc.MerchantId == merchant_id)
                .Where(mc => mc.PaymentTypeId == payment_type_id)
                .Where(mc => mc.CurrencyId == currency_id)
                .FirstOrDefault();
    }

    public MerchantPosCommission? GetMerchantPosCommissionByInstallment(int merchantId, int posId, int installment, bool isCommercialCard, string cardProgram, int currencyId)
    {
        var obj = UnitOfWork.ApplicationDbContext.MerchantPosCommissions.FirstOrDefault(mc => mc.MerchantId == merchantId &&
            mc.PosId == posId &&
            mc.InstallmentNumber == installment &&
            mc.Status == 1);

        return obj;
    }

    internal MerchantsCommission? GetMCommissionMPayment(uint merchant_id, int payment_type_id, int? provider_id, int? operator_id, int currency_id)
    {
        return UnitOfWork.ApplicationDbContext.MerchantsCommissions.Where(mc => mc.MerchantId == merchant_id &&
            mc.CurrencyId == currency_id &&
            mc.Provider == provider_id &&
            mc.PaymentTypeId == payment_type_id).FirstOrDefault();
    }
}
