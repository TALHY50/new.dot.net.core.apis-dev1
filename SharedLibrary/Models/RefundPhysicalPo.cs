using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class RefundPhysicalPo
{
    public int Id { get; set; }

    /// <summary>
    /// merchants table primary id
    /// </summary>
    public int MerchantId { get; set; }

    /// <summary>
    /// amount to be deducted
    /// </summary>
    public double Amount { get; set; }

    /// <summary>
    /// currency table primary id
    /// </summary>
    public sbyte CurrencyId { get; set; }

    /// <summary>
    /// payment source of this transaction
    /// </summary>
    public sbyte PaymentSource { get; set; }

    /// <summary>
    /// payment unique id to distinguish
    /// </summary>
    public string UniqueId { get; set; } = null!;

    /// <summary>
    /// all data of this transaction in a json format 
    /// </summary>
    public string Data { get; set; } = null!;

    /// <summary>
    /// 0 = pending, 1 = processed by cronjob
    /// </summary>
    public sbyte Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
