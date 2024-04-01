using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class MerchantFraud
{
    public ulong Id { get; set; }

    public int MerchantId { get; set; }

    public int CurrencyId { get; set; }

    /// <summary>
    /// 1=active, 0=passive
    /// </summary>
    public sbyte Status { get; set; }

    public double MinAmount { get; set; }

    public double MaxAmount { get; set; }

    public double XValue { get; set; }

    public double YValue { get; set; }

    public double ZValue { get; set; }

    public sbyte? FilterType { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
