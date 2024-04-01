using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class SaleIntegrator
{
    public int Id { get; set; }

    public int SaleId { get; set; }

    public int IntegratorId { get; set; }

    public int MerchantId { get; set; }

    public double CommissionPercentage { get; set; }

    public double? CommissionFixed { get; set; }

    public double CommissionAmount { get; set; }

    public double Amount { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
