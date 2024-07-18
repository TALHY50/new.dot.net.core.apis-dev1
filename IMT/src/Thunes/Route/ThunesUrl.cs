namespace Thunes.Route
{
    public class ThunesUrl
    {
        public const string ConnectivityUrl = "/ping";
        public const string CreateQuotationUrl = "/v2/money-transfer/quotations";
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
        public const string ReportFileDetailUrl = "/v2/money-transfer/reports/{report_id}/files/{id}";
        public const string ListServicesAvailableUrl = "/v2/money-transfer/services";
        public const string ListPayersAvailableUrl = "/v2/money-transfer/payers";
        public const string GetPayerDetailUrl = "/v2/money-transfer/payers/{id}";
        public const string RetrieveRatesForAGivenPayerUrl = "/v2/money-transfer/payers/{id}/rates";
        public const string ListCountriesAvailableUrl = "/v2/money-transfer/countries";
        public const string BicCodeLookupUrl = "/v2/money-transfer/lookups/BIC/{swift_bic_code}";
        public const string SendMoney = "/v2/send-money";
    }
}