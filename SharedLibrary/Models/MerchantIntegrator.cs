using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class MerchantIntegrator
{
    public int Id { get; set; }

    public int MerchantId { get; set; }

    public int IntegratorId { get; set; }

    public double CommissionPercentage { get; set; }

    public double? CommissionFixed { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
