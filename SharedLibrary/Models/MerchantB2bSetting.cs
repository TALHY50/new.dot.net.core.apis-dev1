using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class MerchantB2bSetting
{
    public int Id { get; set; }

    public int? MerchantId { get; set; }

    public sbyte? CurrencyId { get; set; }

    public double? Min { get; set; }

    public double? Max { get; set; }

    public double? CommissionPercentage { get; set; }

    public double? CommissionAmount { get; set; }

    public double ReceiverCommissionPercentage { get; set; }

    public double ReceiverCommissionAmount { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
