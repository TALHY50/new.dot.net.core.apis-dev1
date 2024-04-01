using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class TmpPosInstallment
{
    public int Id { get; set; }

    public int? TmpPosId { get; set; }

    public string PosId { get; set; } = null!;

    public int InstallmentsNumber { get; set; }

    public double? CotPercentage { get; set; }

    /// <summary>
    /// 0=&gt;inactive;1=&gt;active;
    /// </summary>
    public sbyte Status { get; set; }

    public double? CotFixed { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
