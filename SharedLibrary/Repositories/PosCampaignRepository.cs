using Microsoft.EntityFrameworkCore;
using SharedLibrary.Constants;
using SharedLibrary.DTOs;
using SharedLibrary.Interfaces;
using SharedLibrary.Interfaces.Repositories;
using SharedLibrary.Models;

namespace SharedLibrary.Repositories;

public class PosCampaignRepository : GenericRepository<PosCampaign>, IPosCampaignRepository
{

    public const int STATUS_ACTIVE = 1;
    public const int STATUS_INACTIVE = 0;
    public const int MINIMUM_PLUS_INSTALLMENT = 1;
    public const int MINIMUM_BANK_INSTALLMENT = 2;
    public const int IS_ALL_MERCHANT = 1;
    public const int CATEGORY_ALL = 0;
    public const int CATEGORY_ONLY_COMMERCIAL = 1;
    public const int CATEGORY_ONLY_NON_COMMERCIAL = 2;
    public const int CATEGORY_ON_US_COMMERCIAL = 3;
    public const int CATEGORY_NOT_ON_US_COMMERCIAL = 4;

    private readonly IUnitOfWork _unitOfWork;

    public PosCampaignRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }

    public List<PosCampaignPos> GetCampaignByPosIdAndMerchantId(List<int> posIds, int merchantId, bool isCommercialCard, string issuerName = "")
    {
        DateTime currentDate = DateTime.Now;

        var query = _unitOfWork.ApplicationDbContext.PosCampaigns
            .Where(c => posIds.Contains(Convert.ToInt32(c.PosId)))
            .Where(c => c.Status == STATUS_ACTIVE)
            .Where(c => c.FromDate <= currentDate)
            .Where(c => c.ToDate >= currentDate)
            .Where(c => c.IsAllMerchant == IS_ALL_MERCHANT || EF.Functions.Like(c.MerchantIds ?? string.Empty, "%," + merchantId + ",%"))

            .Join(_unitOfWork.ApplicationDbContext.Pos, pCamp => pCamp.PosId, pos => pos.Id, (pCamp, pos) => new PosCampaignPos
            {
                PosCampaign = pCamp,
                Pos = pos
            });
        query = GetCategoryFilterQuery(isCommercialCard, query, issuerName);

        var result = query.ToList();

        return result;

    }

    public List<PosCampaignPos> GetBankInstallmentNumber(int posId, int installment_number, int merchant_id,
        decimal payable_amount, bool isCommercialCard, string issuerName = "")
    {
       


        DateTime current_date = DateTime.Now;
        var query = _unitOfWork.ApplicationDbContext.PosCampaigns
            .Where(c => c.PosId == posId && c.Status == STATUS_ACTIVE)
            .Join(_unitOfWork.ApplicationDbContext.Pos, pCamp => pCamp.PosId, pos => pos.Id, (pCamp, pos) => new PosCampaignPos
            {
                PosCampaign = pCamp,
                Pos = pos
            });

        query = GetCategoryFilterQuery(isCommercialCard, query, issuerName);

        var list = query.Where(q => q.PosCampaign.MaxInstallment >= installment_number ||
            q.PosCampaign.MaxInstallment == 0
        )
        .Where(q => q.PosCampaign.MinTransactionAmount <= (double)payable_amount ||
            q.PosCampaign.MinTransactionAmount == 0)
        .Where(q => q.PosCampaign.MaxTransactionAmount >= (double)payable_amount ||
            q.PosCampaign.MaxTransactionAmount == 0)
        .Where(q => q.PosCampaign.IsAllMerchant == IS_ALL_MERCHANT ||
            EF.Functions.Like(q.PosCampaign.MerchantIds ?? string.Empty, "%," + merchant_id + ",%")
        )
        .Where(q => q.PosCampaign.FromDate <= current_date)
        .Where(q => q.PosCampaign.ToDate >= current_date)
        .OrderByDescending(o => o.PosCampaign.UpdatedAt)
        .ToList();

        return list;

        // code moved to PosService class

      
    }

    public IQueryable<PosCampaignPos> GetCategoryFilterQuery(bool isCommercialCard, IQueryable<PosCampaignPos> query, string issuer_name)
    {


        if (isCommercialCard)
        {
            query = query.Where(pc =>
                (pc.PosCampaign.Category.Contains(Convert.ToString(CATEGORY_ON_US_COMMERCIAL)) && !pc.PosCampaign.Category.Contains(Convert.ToString(CATEGORY_NOT_ON_US_COMMERCIAL)) && pc.Pos.BankName == issuer_name) ||
                (!pc.PosCampaign.Category.Contains(Convert.ToString(CATEGORY_NOT_ON_US_COMMERCIAL)) && pc.PosCampaign.Category.Contains(Convert.ToString(CATEGORY_ON_US_COMMERCIAL)) && pc.Pos.BankName != issuer_name) ||
                (pc.PosCampaign.Category.Contains(Convert.ToString(CATEGORY_ON_US_COMMERCIAL)) && pc.PosCampaign.Category.Contains(Convert.ToString(CATEGORY_NOT_ON_US_COMMERCIAL))) ||
                (!pc.PosCampaign.Category.Contains(Convert.ToString(CATEGORY_NOT_ON_US_COMMERCIAL)) && !pc.PosCampaign.Category.Contains(Convert.ToString(CATEGORY_ON_US_COMMERCIAL)) && pc.Pos.BankName == Convert.ToString(-1))
            );
        }
        else
        {
            query = query.Where(pc => pc.PosCampaign.Category.Contains(Convert.ToString(PosCampaignRepository.CATEGORY_ONLY_NON_COMMERCIAL)));
        }

        

        return query;
    }

    public int BankInstallmentNumber(int installmentNumber, PosCampaign campaign)
    {
        int bankInstallment = 0;

        int minInstallment = Convert.ToInt32(campaign.MinInstallment - campaign.PlusInstallment);

        if (installmentNumber > minInstallment && installmentNumber <= campaign.MaxInstallment)
        {
            if (minInstallment > (installmentNumber - campaign.PlusInstallment))
            {
                bankInstallment = minInstallment;
            }
            else
            {
                bankInstallment = Convert.ToInt32(installmentNumber - campaign.PlusInstallment);
            }
        }

        return bankInstallment;
    }

    public static int GetBonusInstallment(int merchantInstallment, int plusInstallment, int bankInstallment)
    {
        int result = (bankInstallment + plusInstallment) - merchantInstallment;
        if (result > 0)
        {
            return result;
        }
        return 0;
    }
}