using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Transactions;

namespace IMT.Thunes.Route
{
    public class ThunesUrl
    {
        public const string ConnectivityUrl = "/ping";
        public const string CreateQuatationUrl = "/v2/money-transfer/quotations";
        public const string CreateTransactionUrl = "/v2/money-transfer/quotations/{id}/transactions";
        public const string CreateTransactionFromQuotationExternalIdUrl = "/v2/money-transfer/quotations/ext-{external_id}/transactions";
        public const string CreateAttachmentToTransactionByIdUrl = "/v2/money-transfer/transactions/{id}/attachments";
        public const string CreateAttachmentToTransactionByExternalIdUrl = "/v2/money-transfer/transactions/ext-{external_id}/attachments";
        public const string ConfirmTransactionByIdUrl = "/v2/money-transfer/transactions/{id}/confirm";
        public const string ConfirmTransactionByExternalIdUrl = "/v2/money-transfer/transactions/ext-{external_id}/confirm";
        public const string RetrieveTransactionInformationByTransactionIdUrl = "/v2/money-transfer/transactions/{id}";
        public const string RetrieveTransactionInformationByExternalIdUrl = "/v2/money-transfer/transactions/ext-{external_id}";
        public const string ListAttachmentsOfATransactionByIdUrl = "/v2/money-transfer/transactions/{id}/attachments";
        public const string ListAttachmentsOfTransactionByExternalIdUrl = "/v2/money-transfer/transactions/ext-{external_id}/attachments";
        public const string CancelTransactionByIdUrl = "/v2/money-transfer/transactions/{id}/cancel";
        public const string CancelTransactionByExternalIdUrl = "/v2/money-transfer/transactions/{external_id}/cancel";
        public const string RetrieveAQuotationByIdUrl = "/v2/money-transfer/quotations/{id}";
        public const string RetrieveQuotationByExternalIdUrl = "/v2/money-transfer/quotations/ext-{external_id}";
        public const string CreditPartiesInformationUrl = "/v2/money-transfer/payers/{id}/{transaction_type}/credit-party-information";
        public const string CreditPartyVerificationUrl = "/v2/money-transfer/payers/{id}/{transaction_type}/credit-party-verification";
        public const string BalancesUrl = "/v2/money-transfer/balances";
        public const string BalanceMovementUrl = "/v2/money-transfer/balances/{id}/movements";
        public const string ListReportsAvailableUrl = "/v2/money-transfer/reports";
        public const string GetReportDetailUrl = "/v2/money-transfer/reports/{id}";
        public const string ListReportFilesAvailableUrl = "/v2/money-transfer/reports/{id}/files";
    }
}