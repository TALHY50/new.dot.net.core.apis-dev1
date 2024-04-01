using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class PosRedirection
{
    public int Id { get; set; }

    public int FromPosId { get; set; }

    public int ToPosId { get; set; }

    public string? MerchantIds { get; set; }

    /// <summary>
    /// 0=not for all, 1= for all
    /// </summary>
    public sbyte? IsAllMerchant { get; set; }

    public DateTime? FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    /// <summary>
    /// 0= inactive, 1= active
    /// </summary>
    public sbyte? Status { get; set; }

    public int? CreatedById { get; set; }

    public int? UpdatedById { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
