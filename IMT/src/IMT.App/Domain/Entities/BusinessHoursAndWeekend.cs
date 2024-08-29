using System;
using System.Collections.Generic;

namespace IMT.App.Domain.Entities;

/// <summary>
/// Type : Master, regular office hours and weekends
/// </summary>
public partial class BusinessHoursAndWeekend
{
    public uint Id { get; set; }

    /// <summary>
    /// 0 = regular, 1 = special
    /// </summary>
    public byte? HourType { get; set; }

    public uint? CountryId { get; set; }

    /// <summary>
    /// Friday, Saturday, Sunday, Monday, etc
    /// </summary>
    public string Day { get; set; } = null!;

    /// <summary>
    /// 0=not weekend, 1=weekend
    /// </summary>
    public sbyte IsWeekend { get; set; }

    /// <summary>
    /// GMT offset in hours (e.g., +5, -3)
    /// </summary>
    public sbyte Gmt { get; set; }

    public DateTime OpenAt { get; set; }

    public DateTime CloseAt { get; set; }

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
