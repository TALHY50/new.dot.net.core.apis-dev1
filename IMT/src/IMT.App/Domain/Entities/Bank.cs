using System;
using System.Collections.Generic;

namespace IMT.App.Domain.Entities;

public partial class Bank
{
    public uint Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? DisplayName { get; set; }

    public string? Url { get; set; }

    public string? Logo { get; set; }

    public uint? CreatedById { get; set; }

    public uint? UpdatedById { get; set; }

    /// <summary>
    /// 1=active, 0=inactive, 2=soft deleted
    /// </summary>
    public byte Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
