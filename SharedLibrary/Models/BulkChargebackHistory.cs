using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class BulkChargebackHistory
{
    public int Id { get; set; }

    public string PaymentId { get; set; } = null!;

    /// <summary>
    /// chargeback reason
    /// </summary>
    public string? Reason { get; set; }

    /// <summary>
    /// 1=force, 2=request chargeback
    /// </summary>
    public sbyte? Type { get; set; }

    /// <summary>
    /// chargeback failed response
    /// </summary>
    public string? Note { get; set; }

    /// <summary>
    /// transaction amount
    /// </summary>
    public double? Amount { get; set; }

    /// <summary>
    /// transaction currency id
    /// </summary>
    public sbyte? CurrencyId { get; set; }

    /// <summary>
    /// 1=success, 2=failed, 3=partially success
    /// </summary>
    public sbyte? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
