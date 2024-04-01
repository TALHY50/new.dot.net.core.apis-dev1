using SharedLibrary.Models;
using SharedLibrary.Repositories;

namespace SharedLibrary.Interfaces.Repositories;

public interface ISaveCardsRepository : IGenericRepository<SavedCard>
{
    public SavedCard? FindByBrandToken(string brandToken);
    
    public SavedCard? FindByBrandTokenAndCustomerNumber(string brandToken, string customerNumber, bool findAll = false);

    public List<SavedCard> FindAllByMerchantIdAndCustomerNumber(int merchantId, string customerNumber);
}