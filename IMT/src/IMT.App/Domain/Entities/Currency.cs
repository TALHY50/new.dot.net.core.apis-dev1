﻿using System;
using System.Collections.Generic;

namespace IMT.App.Domain.Entities;

public partial class Currency
{
    public uint Id { get; set; }

    public string? Code { get; set; }

    public string? IsoCode { get; set; }

    public string? Name { get; set; }

    public string? Symbol { get; set; }

    public uint? CreatedById { get; set; }

    public uint? UpdatedById { get; set; }

    /// <summary>
    /// 1=active, 0=inactive,2=soft-delete 
    /// </summary>
    public byte? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}