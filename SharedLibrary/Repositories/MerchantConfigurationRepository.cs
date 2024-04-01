using Microsoft.Extensions.Logging;
using SharedLibrary.Models;
using static SharedLibrary.Constants.Constants;

namespace SharedLibrary.Repositories
{
    internal class MerchantConfigurationRepository
    {
        private readonly ILogger<object> _logger;
        private readonly ApplicationDbContext _context;

        public MerchantConfigurationRepository(ILogger<object> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public List<uint> GetMerchantListByEvent(string eventName)
        {
            var query = _context.MerchantConfigurations;
            var commaSeparatedMerchantIds = query.Where(x => x.EventName == eventName)
            .Select(x => x.MerchantIds).FirstOrDefault() ?? "";
            return commaSeparatedMerchantIds.Split(',').Select(uint.Parse).ToList();
        }

        public bool IsDuplicateInvoiceMerchant(uint merchant_id)
        {
            return GetMerchantListByEvent(MerchantConfig.EVENT_DUPLICATE_INVOICE).Contains(merchant_id);
        }
    }
}
