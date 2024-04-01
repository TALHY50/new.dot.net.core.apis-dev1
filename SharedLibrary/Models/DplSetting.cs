using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class DplSetting
{
    public int Id { get; set; }

    public int MerchantId { get; set; }

    public string BrandName { get; set; } = null!;

    public string Logo { get; set; } = null!;

    public string DistanceSaleContract { get; set; } = null!;

    /// <summary>
    /// 1=show distance sale contract, 0=do not show
    /// </summary>
    public sbyte Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
