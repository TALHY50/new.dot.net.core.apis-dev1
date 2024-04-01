using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class IntegratorInstallmentCommission
{
    public int Id { get; set; }

    public int IntegratorId { get; set; }

    public sbyte InstallmentNumber { get; set; }

    public double IntegratorCommissionPercentage { get; set; }

    public double IntegratorCommissionFixed { get; set; }

    /// <summary>
    /// 0 = Inactive, 1 = Active 
    /// </summary>
    public sbyte Status { get; set; }

    public int? CreatedById { get; set; }

    public int? UpdatedById { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
