using Ardalis.SharedKernel;

namespace SharedBusiness.Main.Common.Domain.Entities;

/// <summary>
/// Type : Master, time to complete a transaction.
/// </summary>
public partial class MttPaymentSpeed : EntityBase<uint>, IAggregateRoot
{
    public uint MttId { get; set; }

    /// <summary>
    /// Processing time in minutes
    /// </summary>
    public uint ProcessingTime { get; set; }

    /// <summary>
    /// GMT offset (e.g., +5, -3)
    /// </summary>
    public string Gmt { get; set; }

    /// <summary>
    /// Opening time
    /// </summary>
    public DateTime OpensAt { get; set; }

    /// <summary>
    /// Closing time
    /// </summary>
    public DateTime ClosesAt { get; set; }

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
