using Microsoft.Extensions.Logging;
using SharedLibrary.Interfaces;
using SharedLibrary.Interfaces.Repositories;
using SharedLibrary.Models;

namespace SharedLibrary.Repositories;

public class MerchantPosCommissionsRepository : GenericRepository<MerchantPosCommission>, IMerchantPosCommissionRepository
{
    private readonly ILogger<object> _logger;
    private readonly ApplicationDbContext _context;

    private CommercialCardCommissionRepository _commercialCardCommissionRepository;
    public MerchantPosCommissionsRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        
        _commercialCardCommissionRepository = new CommercialCardCommissionRepository(UnitOfWork);
    }

    public MerchantPosCommission? GetMerchantPosCommissionByInstallment(uint merchant_id, int pos_id, sbyte? installment_number = null, bool is_commercial_card = false, string card_program = "", int currency_id = 0)
    {
        MerchantPosCommission? merchantPosCommission = UnitOfWork.ApplicationDbContext.MerchantPosCommissions
            .FirstOrDefault(mpc => mpc.MerchantId == merchant_id 
                                   && mpc.PosId == pos_id 
                                   && mpc.InstallmentNumber == installment_number 
                                   && mpc.Status == 1);

        if (merchantPosCommission != null && is_commercial_card && !string.IsNullOrEmpty(card_program) && installment_number != null)
        {
            //override MerchantPosCommission with commercial card commissions
            var overrideObj = _commercialCardCommissionRepository.GetByProgram(merchant_id, card_program, currency_id, installment_number.Value);
            
            if(overrideObj != null ){
                merchantPosCommission.ComPercentage = Convert.ToDecimal(overrideObj.MerchantComPercentage);
                merchantPosCommission.ComFixed = Convert.ToDecimal(overrideObj.MerchantComFixed);
                merchantPosCommission.EndUserComPercentage = overrideObj.EndUserComPercentage;
                merchantPosCommission.EndUserComFixed = overrideObj.EndUserComFixed;
            }
        }

        return merchantPosCommission;
    }

}
