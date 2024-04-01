using SharedLibrary.Interfaces;
using SharedLibrary.Interfaces.Repositories;
using SharedLibrary.Models;

namespace SharedLibrary.Repositories;

public class MerchantSettingRepository : GenericRepository<MerchantSetting>, IMerchantSettingRepository
{
    private readonly IUnitOfWork _unitOfWork;
    public MerchantSettingRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _unitOfWork = unitOfWork;

    }
    public MerchantSetting? FindByMerchantId(uint merchantId)
    {
        return _unitOfWork.ApplicationDbContext.MerchantSettings.Where(m => m.MerchantId == merchantId).FirstOrDefault();
    }
    
    
    public MerchantSetting? FindByAppIdAndAppSecret(string appId, string appSecret)
    {
        return _unitOfWork.ApplicationDbContext.MerchantSettings.FirstOrDefault(m => m.AppId == appId && m.AppSecret == appSecret);
    }
}