using System;
using System.Collections.Generic;

namespace SharedKernel.Main.Domain.IMT.Entities;

/// <summary>
/// Type : Master, transaction setup between providers and us, like POS of a payment system
/// </summary>
public partial class Mtt
{
    public uint Id { get; set; }

    public uint? CorridorId { get; set; }

    public uint PayerId { get; set; }

    public uint? ServiceMethodId { get; set; }

    public string TransactionTypeId { get; set; } = null!;

    public uint? CotCurrencyId { get; set; }

    public decimal CotPercentage { get; set; }

    public decimal CotFixed { get; set; }

    public decimal FxSpread { get; set; }

    public uint? MarkUpCurrencyId { get; set; }

    public decimal MarkUpPercentage { get; set; }

    public decimal MarkUpFixed { get; set; }

    /// <summary>
    /// Increment value, definition may vary
    /// </summary>
    public decimal Increment { get; set; }

    public byte MoneyPrecision { get; set; }

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
