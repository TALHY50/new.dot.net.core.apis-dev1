using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class MerchantConfiguration
{
    public int Id { get; set; }

    /// <summary>
    /// Events:
    /// duplicate_invoice,
    /// immediate_refund, ignore_sale_alert
    /// </summary>
    public string EventName { get; set; } = null!;

    /// <summary>
    /// merchant_ids allowed for particular event
    /// </summary>
    public string? MerchantIds { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
