namespace IMT.App.Domain.Entities;

/// <summary>
/// Type : Master, conversion rates based on a corridor
/// </summary>
public partial class CurrencyConversionRate
{
    public uint Id { get; set; }

    public uint CorridorId { get; set; }

    /// <summary>
    /// Exchange rate between currencies
    /// </summary>
    public decimal ExchangeRate { get; set; }

    /// <summary>
    /// Foreign exchange spread
    /// </summary>
    public decimal FxSpread { get; set; }

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
