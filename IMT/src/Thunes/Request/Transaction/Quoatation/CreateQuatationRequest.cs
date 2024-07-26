using Thunes.Request.Common;

namespace Thunes.Request.Transaction.Quoatation
{
    public class CreateQuotationRequest
    {
        public string external_id { get; set; }
        public string payer_id { get; set; }
        public string mode { get; set; }
        public string transaction_type { get; set; }
        public SourceOne source { get; set; }
        public DestinationOne destination { get; set; }
    }
}