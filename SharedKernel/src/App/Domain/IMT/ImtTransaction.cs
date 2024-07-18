namespace App.Domain.IMT;

/// <summary>
/// transaction_type = 1,2,3; 1= send money, 2=receive money etc.transaction_id is sender table id.money_flow = 1/2; 1= incoming and 2 = outgoing, event_type = send money request, send money approved, send money rejected etc.
/// </summary>
public partial class ImtTransaction
{
    public int Id { get; set; }

    public string? PaymentId { get; set; }

    public int? CustomerId { get; set; }

    public int? TransactionStateId { get; set; }

    public int? TransactionId { get; set; }

    /// <summary>
    /// transaction_type = 1 for send, 2 for receive
    /// </summary>
    public sbyte? TransactionType { get; set; }

    /// <summary>
    /// 1 for incoming, 2 for outgoing
    /// </summary>
    public sbyte? MoneyFlow { get; set; }

    public decimal? Amount { get; set; }

    public decimal? Fee { get; set; }

    public decimal? Gross { get; set; }

    public int? CurrencyId { get; set; }

    public decimal? CurrentBalance { get; set; }

    public decimal? PreviousBalance { get; set; }

    /// <summary>
    /// send money request, send money approved, etc
    /// </summary>
    public sbyte? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
