using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class RollingBalance
{
    public const sbyte AWAITING = 0;
    public const sbyte PROCESSED = 1;

    public int Id { get; set; }

    public int? MerchantId { get; set; }

    public int? SaleId { get; set; }

    public double? Amount { get; set; }

    public int? CurrencyId { get; set; }

    /// <summary>
    /// 0=&gt;Awaiting, 1=processed
    /// </summary>
    public sbyte Status { get; set; }

    public DateTime? EffectiveDate { get; set; }

    /// <summary>
    /// 0 = not interrupted, 1= manual interrupted
    /// </summary>
    public sbyte? IsManualPaused { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
