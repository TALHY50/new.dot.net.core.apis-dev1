using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class Commission
{
    public int Id { get; set; }

    public string? TransactionType { get; set; }

    /// <summary>
    /// 1 -&gt; send money 4 -&gt; to_non_supay 5 -&gt; to_banks 6 -&gt; C2B payment 
    /// </summary>
    public sbyte? ActionType { get; set; }

    public int? CurrencyId { get; set; }

    public float CommissionPercentage { get; set; }

    public float CostOfTransactionPercentage { get; set; }

    public double CommissionAmount { get; set; }

    public double CostOfTransactionAmount { get; set; }

    public int? PosId { get; set; }

    public sbyte? OperatorId { get; set; }

    /// <summary>
    /// 1=&gt; wirecard, 2=&gt; payten
    /// </summary>
    public sbyte ProviderId { get; set; }

    public int ServiceId { get; set; }

    public string? ServiceName { get; set; }

    public int ServiceTypeId { get; set; }

    /// <summary>
    /// 1=&gt;Not Verified, 2=&gt;Verified, 3=&gt;Verified Plus
    /// </summary>
    public sbyte? UserCategory { get; set; }

    /// <summary>
    /// 0=&gt;customer, 2=&gt;merchant
    /// </summary>
    public sbyte? UserType { get; set; }

    public sbyte Status { get; set; }

    public string? Name { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
