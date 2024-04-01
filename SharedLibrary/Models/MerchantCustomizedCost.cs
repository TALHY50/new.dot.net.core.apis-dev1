using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class MerchantCustomizedCost
{
    public int Id { get; set; }

    /// <summary>
    ///  Merchant Id
    /// </summary>
    public int MerchantId { get; set; }

    /// <summary>
    /// merchant auth user id
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// currency Id
    /// </summary>
    public int CurrencyId { get; set; }

    public int SettlementId { get; set; }

    /// <summary>
    /// cost to be deducted
    /// </summary>
    public double Amount { get; set; }

    /// <summary>
    /// 0=inactive, 1= active; default 1
    /// </summary>
    public sbyte Status { get; set; }

    /// <summary>
    /// description of the cost
    /// </summary>
    public string Description { get; set; } = null!;

    /// <summary>
    /// Next run date
    /// </summary>
    public DateTime NextActionDate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
