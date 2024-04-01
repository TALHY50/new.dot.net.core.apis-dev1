using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class TmpMerchantPosCommission
{
    public uint Id { get; set; }

    public int TmpAdvanceCommissionId { get; set; }

    public int MerchantId { get; set; }

    public int PosId { get; set; }

    public int InstallmentNumber { get; set; }

    public decimal? ComPercentage { get; set; }

    public decimal? ComFixed { get; set; }

    public double EndUserComPercentage { get; set; }

    public double? EndUserComFixed { get; set; }

    public sbyte Status { get; set; }

    public int? CreatedById { get; set; }

    public int? UpdatedById { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
