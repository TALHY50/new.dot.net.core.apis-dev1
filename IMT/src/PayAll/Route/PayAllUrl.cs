using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMT.PayAll.Route
{
    public class PayAllUrl
    {
        public const string Auth = "/{data}/oauth/token";

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
        public const string GetNewRateByExistRateID = "/v2/exchange-rates/{id}/refresh";
        public const string RequestExchangeRate = "/v2/exchange-rates";
        public const string ConfirmExchangeRate = "/v2/exchange-rates/confirm";
        public const string CancelExchangeRate = "/v2/exchange-rates/cancel";
        public const string GetCardedExchangeRate = "/v2/carded-rates";
        public const string PostCardedExchangeRate = "/v2/payall/carded-rates/{event_type}/{tenant_id}";

        // Accounts
        public const string GetPaymentAccountsList = "/v2/accounts";

        // Recipients
        public const string GetRecipientList = "/v2/recipients";
        public const string CreateRecipient = "/v2/recipients";
        public const string UpdateRecipient = "/v2/recipients/{id}";
        public const string DeleteRecipient = "/v2/recipients/{id}";

        // Discovery
        public const string GetRequiredPaymentFieldsUrl = "/v2/discovery/fields";

        // Payers
        public const string GetPayers = "/v2/payers";
        public const string CreatePayers = "/v2/payers";
        public const string GetPayer = "/v2/payers/{id}";
        public const string GetPayerAccounts = "/v2/payers/{id}/accounts";

        // Compliance
        public const string UploadNewComplianceDocumentUrl = "/v2/documents";


    }

}
