using SharedLibrary.Models;

namespace SharedLibrary.Interfaces.Repositories;

public interface IMerchantSettingRepository : IGenericRepository<MerchantSetting>
{
    public MerchantSetting? FindByMerchantId(uint merchantId);

    public MerchantSetting? FindByAppIdAndAppSecret(string appId, string appSecret);

}