

using IMT.PayAll.Response.Common;

namespace IMT.PayAll.Request
{
    public class RequestExchangeRate
    {
        public SourceAmount source_amount { get; set; }
        public TargetAmount target_amount { get; set; }
        public string source_account_id { get; set; }
        public string source_currency { get; set; }
        public string recipient_instrument_id { get; set; }
        public string payment_instrument_category { get; set; }
        public string payment_type { get; set; }
        public string target_currency { get; set; }
        public string destination_country { get; set; }


    }

}