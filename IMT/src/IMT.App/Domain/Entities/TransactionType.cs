namespace IMT.App.Domain.Entities;

/// <summary>
/// Type : Master, transaction models for business and consumers
/// </summary>
public partial class TransactionType
{
    public uint Id { get; set; }

    /// <summary>
    /// 1 = B2B, 2 = B2C, 3 = C2B, 4 = C2C, 5 = M2M
    /// </summary>
    public byte Type { get; set; }

    public uint? CompanyId { get; set; }

    /// <summary>
    /// 0=inactive, 1=active, 2=pending, 3=rejected 
    /// </summary>
    public byte Status { get; set; }

    public uint? CreatedById { get; set; }

    public uint? UpdatedById { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
