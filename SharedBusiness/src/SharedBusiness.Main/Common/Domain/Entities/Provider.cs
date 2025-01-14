﻿using Ardalis.SharedKernel;

namespace SharedBusiness.Main.Common.Domain.Entities;

public partial class Provider : EntityBase<uint>, IAggregateRoot
{
    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? BaseUrl { get; set; }

    public string? ApiKey { get; set; }

    public string? ApiSecret { get; set; }

    /// <summary>
    /// 1= active, 0 =inactive, 2 =soft-deleted
    /// </summary>
    public byte? Status { get; set; }

    public uint? CreatedById { get; set; }

    public uint? UpdatedById { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
