using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class MerchantOnboardingPosSetting
{
    public int Id { get; set; }

    public int MerchantOnboardingApiSettingsId { get; set; }

    public int PosId { get; set; }

    public double CommissionPercentage { get; set; }

    public double CommissionFixed { get; set; }

    public double EndUserCommissionPercentage { get; set; }

    public double EndUserCommissionFixed { get; set; }

    /// <summary>
    /// 0 =&gt; inactive , 1 =&gt; active
    /// </summary>
    public sbyte IsAllowForeignCard { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
