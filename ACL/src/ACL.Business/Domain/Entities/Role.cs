﻿using Ardalis.SharedKernel;

namespace ACL.Business.Domain.Entities;

public partial class Role : EntityBase<uint>, IAggregateRoot
{
    public string? Title { get; set; }

    public string? Name { get; set; }

    public sbyte Status { get; set; }

    public uint CompanyId { get; set; }

    /// <summary>
    /// creator auth ID
    /// </summary>
    public uint? CreatedById { get; set; }

    /// <summary>
    /// approve auth ID
    /// </summary>
    public uint? UpdatedById { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
