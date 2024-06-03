using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMT.PayAll.Route
{
    public class PayAllUrl
    {
        public const string Auth = "/oauth/token";
        public const string SinglePayment = "/v2/single-payment";
        public const string GetPaymentById = "/v2/payments/";
        public const string UpdatePaymentById = "/v2/payments/";
    }
}