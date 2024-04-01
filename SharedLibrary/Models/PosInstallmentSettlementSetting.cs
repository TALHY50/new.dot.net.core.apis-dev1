using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class PosInstallmentSettlementSetting
{
    public int Id { get; set; }

    public string PosId { get; set; } = null!;

    /// <summary>
    /// 0 = single installment, 1 = 1st payment of installment, others are regular installment number
    /// </summary>
    public int InstallmentsNumber { get; set; }

    /// <summary>
    /// The day installment amount will be settle to merchant wallet.For example 30. installment amount will be settle after 30 days from sale date
    /// </summary>
    public int SettlementDay { get; set; }

    /// <summary>
    /// 0=&gt;inactive;1=&gt;active;
    /// </summary>
    public sbyte Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
