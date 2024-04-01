using SharedLibrary.Interfaces;
using SharedLibrary.Interfaces.Repositories;
using SharedLibrary.Models;

namespace SharedLibrary.Repositories;

public class SaveCardsRepository : GenericRepository<SavedCard>, ISaveCardsRepository
{
    public SaveCardsRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {

    }
    
    
    public SavedCard? FindByBrandToken(string brandToken)
    {

        SavedCard? savedCard =
            UnitOfWork.ApplicationDbContext.SavedCards.FirstOrDefault(x => x.BrandToken == brandToken);

        return savedCard;

    }
    
    public SavedCard? FindByBrandTokenAndCustomerNumber(string brandToken, string customerNumber, bool findAll = false)
    {

        SavedCard? savedCard =
            UnitOfWork.ApplicationDbContext.SavedCards.FirstOrDefault(x => x.BrandToken == brandToken && x.CustomerNumber == customerNumber);

        return savedCard;

    }
    
    
    public List<SavedCard> FindAllByMerchantIdAndCustomerNumber(int merchantId, string customerNumber)
    {

        List<SavedCard> savedCards =
            UnitOfWork.ApplicationDbContext.SavedCards.Where(x => x.MerchantId == merchantId && x.CustomerNumber == customerNumber).ToList();

        return savedCards;

    }
}