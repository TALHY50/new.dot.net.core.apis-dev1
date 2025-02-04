﻿using Ardalis.SharedKernel;

namespace SharedBusiness.Main.Common.Domain.Entities;

/// <summary>
/// Type : Master, we onboard an institution, and perform transactions under it, like the merchants of a payment system
/// </summary>
public partial class Institution : EntityBase<uint>, IAggregateRoot
{
    /// <summary>
    /// name of the institution
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Url of the official site
    /// </summary>
    public string? Url { get; set; }

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
