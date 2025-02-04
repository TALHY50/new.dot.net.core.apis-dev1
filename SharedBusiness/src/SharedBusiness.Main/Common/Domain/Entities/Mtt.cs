﻿using Ardalis.SharedKernel;

namespace SharedBusiness.Main.Common.Domain.Entities;

/// <summary>
/// Type : Master, transaction setup between providers and us, like POS of a payment system
/// </summary>
public partial class Mtt  : EntityBase<uint>, IAggregateRoot
{
    public uint? CorridorId { get; set; }

    public uint? CurrencyId { get; set; }

    public uint PayerId { get; set; }

    public uint? ServiceMethodId { get; set; }

    public uint TransactionTypeId { get; set; }

    public decimal CotPercentage { get; set; }

    public decimal CotFixed { get; set; }

    public decimal FxSpread { get; set; }

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
