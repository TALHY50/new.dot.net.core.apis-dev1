using System;
using System.Collections.Generic;

namespace IMT.App.Domain.Entities;

/// <summary>
/// Type : Master; Regions like Asia Pacific, SARC. Every country belongs to a region
/// </summary>
public partial class Region
{
    public uint Id { get; set; }

    /// <summary>
    /// Example : EuroZone, Asia Pacific
    /// </summary>
    public string? Name { get; set; }

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
