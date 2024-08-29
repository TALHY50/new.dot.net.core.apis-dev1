using System;
using System.Collections.Generic;

namespace IMT.App.Domain.Entities;

/// <summary>
/// Type : Master, for every transaction it takes time to process the transactions, this is the setup in payers&apos; context
/// </summary>
public partial class PayerPaymentSpeed
{
    public uint Id { get; set; }

    public uint PayerId { get; set; }

    /// <summary>
    /// Processing time in minutes
    /// </summary>
    public uint ProcessingTime { get; set; }

    /// <summary>
    /// GMT offset in hours (e.g., +5, -3)
    /// </summary>
    public sbyte Gmt { get; set; }

    /// <summary>
    /// Opening time
    /// </summary>
    public DateTime OpenAt { get; set; }

    /// <summary>
    /// Closing time
    /// </summary>
    public DateTime CloseAt { get; set; }

    /// <summary>
    /// CSV of weekdays (e.g., Monday,Tuesday)
    /// </summary>
    public string WorkingDays { get; set; } = null!;

    /// <summary>
    /// 0 = No, 1 = Yes
    /// </summary>
    public bool IsProcessingDuringBankingHoliday { get; set; }

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
