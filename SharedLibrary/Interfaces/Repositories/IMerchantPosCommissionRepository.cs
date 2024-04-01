using SharedLibrary.Models;

namespace SharedLibrary.Interfaces.Repositories;

public interface IMerchantPosCommissionRepository : IGenericRepository<MerchantPosCommission>
{
    public MerchantPosCommission? GetMerchantPosCommissionByInstallment(uint merchant_id, int pos_id,
        sbyte? installment_number = null, bool is_commercial_card = false, string card_program = "",
        int currency_id = 0);
    
    

}