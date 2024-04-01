using SharedLibrary.Interfaces;
using SharedLibrary.Interfaces.Repositories;
using SharedLibrary.Models;

namespace SharedLibrary.Repositories;

public class MerchantWebHookKeysRepository : GenericRepository<MerchantWebHookKey>, IMerchantWebHookKeysRepository
{
    public MerchantWebHookKeysRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public MerchantWebHookKey? FindByMerchantId(int merchantId, string keyName = "", sbyte? type = null)
    {
        var q =UnitOfWork.ApplicationDbContext.MerchantWebHookKeys
            .Where(x => x.MerchantId == merchantId);

        if (keyName != "")
        {
            q.Where(x => x.KeyName == keyName);
        }

        if (type != null)
        {
            q.Where(x => x.Type == type);

        }


        return q.FirstOrDefault();


    }
}