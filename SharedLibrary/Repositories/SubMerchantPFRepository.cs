using Microsoft.Extensions.Logging;
using SharedLibrary.Models;

namespace SharedLibrary.Repositories
{
    public class SubMerchantPFRepository
    {
        private readonly ILogger<object> _logger;
        private readonly ApplicationDbContext _context;

        
        public SubMerchantPFRepository(ILogger<object> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public SubMerchantPf? FindActivePFRecordByMerchantIdAndPFId(int merchant_id, string pf_id)
        {
            var subMerchantPFObj = _context.SubMerchantPfs.FirstOrDefault(s => s.MerchantId == merchant_id &&
                                                                               s.PfId == pf_id && 
                                                                               s.Status == 1);

            return subMerchantPFObj;

        }
    }
}
