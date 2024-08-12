namespace SharedKernel.Main.Domain.IMT;

public partial class TransactionType
{
    public int Id { get; set; }

    /// <summary>
    /// send money, receive money, withdrawal etc
    /// </summary>
    public string? Name { get; set; }

    public sbyte? Status { get; set; }

    public int? CreatedById { get; set; }

    public int? UpdatedById { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
