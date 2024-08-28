namespace IMT.App.Domain.Entities;

public partial class Transaction
{
    public int Id { get; set; }

    public string? PaymentId { get; set; }

    public int? CustomerId { get; set; }

    public int? TransactionStateId { get; set; }

    public int? TransactionId { get; set; }

    /// <summary>
    /// 1= send money, 2=receive money 
    /// </summary>
    public sbyte? TransactionType { get; set; }

    /// <summary>
    /// For refund, it would be corresponding sale id
    /// </summary>
    public int TransactionReferenceId { get; set; }

    /// <summary>
    /// 1= incoming and 2 = outgoing
    /// </summary>
    public sbyte? MoneyFlow { get; set; }

    public decimal? Amount { get; set; }

    public decimal? Fee { get; set; }

    public decimal? Gross { get; set; }

    public int? CurrencyId { get; set; }

    public decimal? CurrentBalance { get; set; }

    public decimal? PreviousBalance { get; set; }

    /// <summary>
    /// 0=pending, 1=approved, 2=reject
    /// </summary>
    public sbyte? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
