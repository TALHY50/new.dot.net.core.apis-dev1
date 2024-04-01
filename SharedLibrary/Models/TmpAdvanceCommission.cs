using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class TmpAdvanceCommission
{
    public int Id { get; set; }

    public int MerchantId { get; set; }

    public int PosId { get; set; }

    /// <summary>
    /// 0=not processed yet by Cron; 1=already processed by cron
    /// </summary>
    public sbyte? EffectiveStatus { get; set; }

    public sbyte IsAllowForeignCard { get; set; }

    public DateTime? EffectiveDate { get; set; }

    public int? CreatedById { get; set; }

    public int? UpdatedById { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
