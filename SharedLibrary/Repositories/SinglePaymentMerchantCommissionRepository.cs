using Microsoft.Extensions.Logging;
using SharedLibrary.Interfaces;
using SharedLibrary.Interfaces.Repositories;
using SinglePaymentMerchantCommission = SharedLibrary.Models.SinglePaymentMerchantCommission;

namespace SharedLibrary.Repositories
{
    public class SinglePaymentMerchantCommissionRepository : GenericRepository<SinglePaymentMerchantCommission>, ISinglePaymentMerchantCommissionRepository
    {
        private readonly ILogger<object> _logger;

        private readonly IUnitOfWork _unitOfWork;

        
        public SinglePaymentMerchantCommissionRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public SinglePaymentMerchantCommission? CheckForSinglePaymentMerchantCommission(uint merchant_id,int currency_id, string card_type, string issuer_name)
        {
            
            var cardType = (card_type == "DEBIT CARD") ? SinglePaymentMerchantCommission.CARD_TYPE_DEBIT
            : SinglePaymentMerchantCommission.CARD_TYPE_CREDIT;

            var commission = _unitOfWork.ApplicationDbContext.SinglePaymentMerchantCommissions
                .FirstOrDefault(c => c.MerchantId == merchant_id &&
                                     c.CurrencyId == currency_id && 
                                     c.IssuerName == issuer_name && 
                                     c.CardType == cardType && 
                                     c.Status == 1);
            
            return commission;
        }
    }
}
