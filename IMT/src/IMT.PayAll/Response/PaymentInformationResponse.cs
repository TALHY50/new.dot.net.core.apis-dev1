
using IMT.PayAll.Response.Common;

namespace IMT.PayAll.Response
{
    public class PaymentInformationResponse
    {
        public string client_payment_id { get; set; }
        public string id { get; set; }
        public string status { get; set; }
        public Fees fees { get; set; }
        public ExchangeRate exchange_rate { get; set; }
        public string recipient_id { get; set; }
        public string payment_instrument_id { get; set; }

    }


}
