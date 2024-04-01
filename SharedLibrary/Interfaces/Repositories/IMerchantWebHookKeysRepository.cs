using SharedLibrary.Models;

namespace SharedLibrary.Interfaces.Repositories;

public interface IMerchantWebHookKeysRepository : IGenericRepository<MerchantWebHookKey>
{

    public MerchantWebHookKey? FindByMerchantId(int merchantId, string keyName = "", sbyte? type = null);

}