using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMT.PayAll.Route
{
    public class PayAllUrl
    {
        public const string Auth = "/oauth/token";

        // Payments
        public const string SinglePayment = "/v2/single-payment";
        public const string GetPaymentById = "/v2/payments/{id}";
        public const string UpdatePaymentById = "/v2/payments/{id}";

        // Payment Instruments
        public const string PaymentInstrumentsList = "/v2/payment-instruments";
        public const string CreatePaymentInstruments = "/v2/payment-instruments";
        public const string GetPaymentInstrumentsByID = "/v2/payment-instruments/{id}";
        public const string DeletePaymentInstrumentsByID = "/v2/payment-instruments/{id}";
        public const string UpdatePaymentInstrumentsByID = "/v2/payment-instruments/{id}";

        //Exchange
        public const string GetExchangeRateByID = "/v2/exchange-rates/{id}";
        

}

}
