using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class MerchantOperationCommission
{
    public int Id { get; set; }

    public int MerchantId { get; set; }

    public sbyte CurrencyId { get; set; }

    /// <summary>
    /// 1:withdrawal, 2:deposit-eft
    /// </summary>
    public sbyte Type { get; set; }

    public double Min { get; set; }

    public double Max { get; set; }

    public double CommissionPercentage { get; set; }

    public double CommissionFixed { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
