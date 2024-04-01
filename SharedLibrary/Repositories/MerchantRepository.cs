using SharedLibrary.Interfaces;
using SharedLibrary.Interfaces.Repositories;
using SharedLibrary.Models;

namespace SharedLibrary.Repositories
{
    public class MerchantRepository : GenericRepository<Merchant>, IMerchantRepository
    {
        public MerchantRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public Merchant? FindById(uint merchantId)
        {
            return UnitOfWork.ApplicationDbContext.Merchants.FirstOrDefault(s => s.Id == merchantId);
        }

        public Merchant? FindActiveMerchantById(int? linkedPfMerchantId)
        {
            return UnitOfWork.ApplicationDbContext.Merchants.FirstOrDefault(s => s.Id == linkedPfMerchantId && s.Status == 1 && s.IsBlock == 0);
        }

        public Merchant? FindActiveMerchantByKey(string key)
        {
            return UnitOfWork.ApplicationDbContext.Merchants.FirstOrDefault(o => o.MerchantKey == key && o.Status == 1 && o.IsBlock == 0);
        }

        public Merchant? FindByUserId(int userId)
        {
            return UnitOfWork.ApplicationDbContext.Merchants.FirstOrDefault(s => s.UserId == userId);
        }

        public List<string> GetMerchantListByEvent(string eventName)
        {
            return UnitOfWork.ApplicationDbContext.MerchantConfigurations.Where(x => x.EventName == eventName).Select(x => x.MerchantIds!).ToList();
        }

        public Merchant? FindByType(int type)
        {
            Merchant? merchant = UnitOfWork.ApplicationDbContext.Merchants.FirstOrDefault(x => x.Type == type);

            return merchant;
        }


        
    }
}
