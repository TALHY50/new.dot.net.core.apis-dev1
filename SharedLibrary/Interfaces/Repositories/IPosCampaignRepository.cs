using SharedLibrary.DTOs;
using SharedLibrary.Models;

namespace SharedLibrary.Interfaces.Repositories;

public interface IPosCampaignRepository: IGenericRepository<PosCampaign>
{
    public List<PosCampaignPos> GetCampaignByPosIdAndMerchantId(List<int> pos_id, int merchant_id,
        bool is_commercial_card, string issuer_name = "");

    public List<PosCampaignPos> GetBankInstallmentNumber(int posId, int installment_number,
        int merchant_id, decimal payable_amount, bool isCommercialCard,string issuerName = "");

    public IQueryable<PosCampaignPos> GetCategoryFilterQuery(bool isCommercialCard, IQueryable<PosCampaignPos> query, string issuer_name);


    public int BankInstallmentNumber(int installmentNumber, PosCampaign posCampaign);






}