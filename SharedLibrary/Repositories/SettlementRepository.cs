using SharedLibrary.Constants;
using SharedLibrary.Interfaces;
using SharedLibrary.Interfaces.Repositories;
using SharedLibrary.Models;

namespace SharedLibrary.Repositories;

public class SettlementRepository : GenericRepository<Settlement>, ISettlementRepository
{
    public SettlementRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }

    public int? ChooseSettlementIdByInstallment(int installmentNumber, int? settlementId, int? SinglePaymentSettlementId)
    {
        if (SinglePaymentSettlementId != 0 && IsAllowDifferentSettlementForSingleAndMultipleInstallment())
        {
            if (installmentNumber != 0 || installmentNumber <= 1)
            {
                settlementId = SinglePaymentSettlementId;
            }
        }
        return settlementId;
    }

    private bool IsAllowDifferentSettlementForSingleAndMultipleInstallment()
    {
        var brandCode = Brand.name_code;
        string[] brandList = { SharedLibrary.Constants.Constants.BRAND_NAME_CODE_LIST["FP"] };

        return brandList.Contains(brandCode);
    }

    public Settlement FirstById(int settlementId)
    {
        return UnitOfWork.ApplicationDbContext.Settlements.FirstOrDefault(x => x.Id == settlementId)!;
    }

    public Settlement GetSettlemnetById(int? settlementId)
    {
        return UnitOfWork.ApplicationDbContext.Settlements.FirstOrDefault(x => x.Id == settlementId && x.Status == 1)!;
    }
}