namespace SharedKernel.Main.IMT.Domain.Entities;

public partial class PaymentMethod
{
    public int Id { get; set; }

    public string? MethodName { get; set; }

    public string? Description { get; set; }

    public int? CreatedById { get; set; }

    public int? UpdatedById { get; set; }

    /// <summary>
    /// 1= active, 0=inactive, 2=soft-deleted
    /// </summary>
    public sbyte? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
