using System;
using System.Collections.Generic;

namespace SharedKernel.Main.Domain.IMT.Entities;

/// <summary>
/// Type : Master, channels being used for money transfers, like Thunes, PayAll, Mastercard
/// </summary>
public partial class Provider
{
    public uint Id { get; set; }

    public string Name { get; set; } = null!;

    /// <summary>
    /// base_url of the APIs
    /// </summary>
    public string BaseUrl { get; set; } = null!;

    public string AppId { get; set; } = null!;

    public string AppSecret { get; set; } = null!;

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
