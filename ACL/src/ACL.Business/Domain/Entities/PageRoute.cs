﻿using Ardalis.SharedKernel;

namespace ACL.Business.Domain.Entities;

public partial class PageRoute : EntityBase<ulong>, IAggregateRoot
{
    public ulong? PageId { get; set; }

    public string? RouteName { get; set; }

    public string? RouteUrl { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
