﻿using Ardalis.SharedKernel;

namespace SharedBusiness.Main.Common.Domain.Entities;

/// <summary>
/// Type : Master; Regions like Asia Pacific, SARC. Every country belongs to a region
/// </summary>
public partial class Region : EntityBase<uint>, IAggregateRoot
{
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
