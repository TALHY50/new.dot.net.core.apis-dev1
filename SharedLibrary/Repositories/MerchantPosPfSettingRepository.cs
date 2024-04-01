using Microsoft.Extensions.Logging;
using SharedLibrary.Interfaces;
using SharedLibrary.Models;

namespace SharedLibrary.Repositories
{
    public class MerchantPosPfSettingRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<object> _logger;
        private readonly ApplicationDbContext _context;

        public static readonly sbyte STATUS_ACTIVE = 1;
        public static readonly sbyte STATUS_INACTIVE = 0;

        public MerchantPosPfSettingRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public MerchantPosPfSetting? FindByMerchantIdAndPosId(uint merchantId, int posId, sbyte? status)
        {
            var query = _unitOfWork.ApplicationDbContext.MerchantPosPfSettings.Where(s=>s.MerchantId==merchantId && s.PosId==posId);
            if(status != null)query=query.Where(s=>s.Status==status);

            return query.FirstOrDefault();
        }

    }

}