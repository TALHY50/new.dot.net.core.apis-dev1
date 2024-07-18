namespace SharedKernel.Domain.IMT;

public partial class ImtTransactionState
{
    public int Id { get; set; }

    public string? Name { get; set; }

    /// <summary>
    /// 1=completed, 2=pending, 3=approved, 4=
    /// </summary>
    public sbyte? Status { get; set; }

    public int? CreatedById { get; set; }

    public int? UpdatedById { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
