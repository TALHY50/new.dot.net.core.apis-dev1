namespace IMT.App.Domain.Entities;

public partial class MoneyTransferReport
{
    public uint Id { get; set; }

    public uint MoneyTransferQuotationId { get; set; }

    public uint? MoneyTransferInstitutionId { get; set; }

    public string? MoneyTransferInvoiceId { get; set; }

    public string? MoneyTransferOrderId { get; set; }

    public string? MoneyTransferPaymentId { get; set; }

    /// <summary>
    /// Transaction id  by providers
    /// </summary>
    public string? MoneyTransferRemoteOrderId { get; set; }

    public sbyte? MoneyTransferMode { get; set; }

    public decimal? MoneyTransferRequestAmount { get; set; }

    public uint? MoneyTransferCurrencyId { get; set; }

    public uint? MoneyTransferMttId { get; set; }

    public decimal? MoneyTransferExchangeRate { get; set; }

    public decimal? MoneyTransferCommission { get; set; }

    public decimal? MoneyTransferCot { get; set; }

    public decimal? MoneyTransferTax { get; set; }

    public decimal? MoneyTransferSendAmount { get; set; }

    public int? MoneyTransferTransactionStateId { get; set; }

    public DateTime? RemoteTransactionDatetime { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
