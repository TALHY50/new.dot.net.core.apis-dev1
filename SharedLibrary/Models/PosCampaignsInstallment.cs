using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class PosCampaignsInstallment
{
    public int Id { get; set; }

    public string PosId { get; set; } = null!;

    public int PosCampaignId { get; set; }

    public int InstallmentsNumber { get; set; }

    public double? CotPercentage { get; set; }

    public double? CotFixed { get; set; }

    /// <summary>
    /// 0=&gt;inactive;1=&gt;active;
    /// </summary>
    public sbyte Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
