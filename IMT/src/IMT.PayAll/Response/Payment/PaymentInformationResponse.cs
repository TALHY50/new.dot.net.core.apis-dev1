﻿using IMT.PayAll.Response.Common;

namespace IMT.PayAll.Response.Payment
{
    public class PaymentInformationResponse
    {
        public string client_payment_id { get; set; }
        public Guid id { get; set; }
        public string status { get; set; }
        public Fees fees { get; set; }
        public ExchangeRate exchange_rate { get; set; }
        public string recipient_id { get; set; }
        public string payment_instrument_id { get; set; }

    }


}