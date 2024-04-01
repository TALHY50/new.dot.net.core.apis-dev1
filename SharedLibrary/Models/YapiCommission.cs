using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class YapiCommission
{
    public int Id { get; set; }

    public string MerchantId { get; set; } = null!;

    public double FromAmount { get; set; }

    public double ToAmount { get; set; }

    public double ComFixed { get; set; }

    public double ComPercentage { get; set; }

    public int CurrencyId { get; set; }

    public sbyte Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
