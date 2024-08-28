namespace IMT.App.Domain.Entities;

/// <summary>
/// Type : Master, transaction limits based on various entity like corridors, countries, mtts
/// </summary>
public partial class TransactionLimit
{
    public uint Id { get; set; }

    /// <summary>
    /// Type of entity (mtts, corridors, countries)
    /// </summary>
    public string EntityType { get; set; } = null!;

    /// <summary>
    /// ID of the entity
    /// </summary>
    public uint EntityId { get; set; }

    /// <summary>
    /// Aggregation type of transactions
    /// </summary>
    public string AggregationType { get; set; } = null!;

    /// <summary>
    /// Transfer point (source or destination)
    /// </summary>
    public string TransferPoint { get; set; } = null!;

    /// <summary>
    /// Periodicity of the limit
    /// </summary>
    public string PeriodicityType { get; set; } = null!;

    /// <summary>
    /// Currency ID for the amount
    /// </summary>
    public uint AmountCurrencyId { get; set; }

    /// <summary>
    /// Maximum transaction amount
    /// </summary>
    public decimal Max { get; set; }

    /// <summary>
    /// Minimum transaction amount
    /// </summary>
    public decimal Min { get; set; }

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
