using System;
using System.Collections.Generic;

namespace SharedKernel.Main.Domain.IMT.Entities;

/// <summary>
/// Type : Master, mtt(s) assigned to an institution
/// </summary>
public partial class InstitutionMtt
{
    public uint Id { get; set; }

    public uint InstitutionId { get; set; }

    public uint MttId { get; set; }

    /// <summary>
    /// 1 = Regular, 2 = Some-other-type
    /// </summary>
    public byte CommissionType { get; set; }

    public uint? CommissionCurrencyId { get; set; }

    public decimal CommissionPercentage { get; set; }

    public decimal CommissionFixed { get; set; }

    public uint? CompanyId { get; set; }

    /// <summary>
    /// 0=inactive, 1=active, 2=pending, 3=rejected 
    /// </summary>
    public byte Status { get; set; }

    public uint? CreatedById { get; set; }

    public uint? UpdatedById { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
