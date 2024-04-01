using Merchant = SharedLibrary.Models.Merchant;

namespace SharedLibrary.Interfaces.Repositories;

public interface IMerchantRepository : IGenericRepository<Merchant>
{
    public Merchant? FindById(uint merchantId);
    public Merchant? FindActiveMerchantById(int? linkedPfMerchantId);
    public Merchant? FindActiveMerchantByKey(string key);
    public Merchant? FindByUserId(int userId);
    public List<string> GetMerchantListByEvent(string eventName);

    public Merchant? FindByType(int type);
}