using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMT.Thunes.Route
{
    public class ThunesUrl
    {
        public const string CreateQuatationUrl = "/v2/money-transfer/quotations";
        public const string CreateTransactionUrl = "/v2/money-transfer/quotations/{id}/transactions";
        public const string CreateTransactionFromQuotationExternalIdUrl = "/v2/money-transfer/quotations/ext-{external_id}/transactions";
        public const string RetrieveAQuotationByIdUrl = "/v2/money-transfer/quotations/{id}";
        public const string RetrieveQuotationByExternalIdUrl = "/v2/money-transfer/quotations/ext-{external_id}";
        public const string CreditPartiesInformationUrl = "/v2/money-transfer/payers/{id}/{transaction_type}/credit-party-information";
    }
}