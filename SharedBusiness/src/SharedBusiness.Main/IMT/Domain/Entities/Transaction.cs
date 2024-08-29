namespace SharedBusiness.Main.IMT.Domain.Entities;

public partial class Transaction
{
    public uint Id { get; set; }

    public string? PaymentId { get; set; }

    public uint? CustomerId { get; set; }

    public uint? TransactionStateId { get; set; }

    public uint? TransactionId { get; set; }

    /// <summary>
    /// 1= send money, 2=receive money 
    /// </summary>
    public sbyte? TransactionType { get; set; }

    /// <summary>
    /// For refund, it would be corresponding sale id
    /// </summary>
    public uint TransactionReferenceId { get; set; }

    /// <summary>
    /// 1= incoming and 2 = outgoing
    /// </summary>
    public sbyte? MoneyFlow { get; set; }

    public decimal? Amount { get; set; }

    public decimal? Fee { get; set; }

    public decimal? Gross { get; set; }

    public uint? CurrencyId { get; set; }

    public decimal? CurrentBalance { get; set; }

    public decimal? PreviousBalance { get; set; }

    /// <summary>
    /// 0=pending, 1=approved, 2=reject
    /// </summary>
    public byte? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
