using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class MerchantB2cSetting
{
    public int Id { get; set; }

    public int? MerchantId { get; set; }

    public sbyte? CurrencyId { get; set; }

    /// <summary>
    /// 1-&gt;cashout to bank;2-&gt;cashout to wallet
    /// </summary>
    public sbyte? Type { get; set; }

    public double? Min { get; set; }

    public double? Max { get; set; }

    public double? SenderCommissionPercentage { get; set; }

    public double? SenderCommissionFixed { get; set; }

    public double? ReceiverCommissionPercentage { get; set; }

    public double? ReceiverCommissionFixed { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
