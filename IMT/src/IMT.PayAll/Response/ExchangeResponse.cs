

using IMT.PayAll.Response.Common;

namespace IMT.PayAll.Response
{
    public class ExchangeResponse
    {
        public string id { get; set; }
        public SourceAmount source_amount { get; set; }
        public TargetAmount target_amount { get; set; }
        public DateTime expiration_date { get; set; }
    }
    
}
