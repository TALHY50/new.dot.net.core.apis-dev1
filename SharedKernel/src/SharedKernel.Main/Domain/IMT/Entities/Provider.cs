﻿using System;
using System.Collections.Generic;

namespace SharedKernel.Main.Domain.IMT.Entities;

public partial class Provider
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? BaseUrl { get; set; }

    public string? ApiKey { get; set; }

    public string? ApiSecret { get; set; }

    /// <summary>
    /// 1= active, 0 =inactive, 2 =soft-deleted
    /// </summary>
    public sbyte? Status { get; set; }

    public int? CreatedById { get; set; }

    public int? UpdatedById { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
