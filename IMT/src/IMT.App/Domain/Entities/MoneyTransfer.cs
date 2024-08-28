namespace IMT.App.Domain.Entities;

public class MoneyTransfer
{
    public int Id { get; set; }
    public uint QuotationId { get; set; }
    public uint? InstitutionId { get; set; }
    public string InvoiceId { get; set; }
    public string OrderId { get; set; }
    public string PaymentId { get; set; }
    public string RemoteOrderId { get; set; }
    public byte? Mode { get; set; }
    public decimal? RequestAmount { get; set; }
    public uint? CurrencyId { get; set; }
    public uint? MttId { get; set; }
    public decimal? ExchangeRate { get; set; }
    public decimal? Commission { get; set; }
    public decimal? Cot { get; set; }
    public decimal? Tax { get; set; }
    public decimal? MarkUp { get; set; }
    public decimal? MarkUpPercentage { get; set; }
    public decimal? MarkUpFixed { get; set; }
    public decimal? SendAmount { get; set; }
    public int? TransactionStateId { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}