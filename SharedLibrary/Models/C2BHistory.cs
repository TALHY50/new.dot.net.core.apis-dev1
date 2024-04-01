using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class C2BHistory
{
    public int Id { get; set; }

    public int? ReceiverMerchantId { get; set; }

    public string? ReceiverMerchantName { get; set; }

    public int? ReceiverId { get; set; }

    public string? ReceiverGsmNumber { get; set; }

    public int? SenderId { get; set; }

    public string? SenderName { get; set; }

    public string? SenderGsmNumber { get; set; }

    public int? SendId { get; set; }

    public double? Amount { get; set; }

    public double? MerchantCommissionPercentage { get; set; }

    public double? MerchantCommissionFixed { get; set; }

    public double? MerchantRollingPercentage { get; set; }

    public string? Description { get; set; }

    public int? CurrencyId { get; set; }

    public string? CurrencySymbol { get; set; }

    /// <summary>
    /// 0=&gt;Awaiting, 1=&gt;Processed
    /// </summary>
    public sbyte? Status { get; set; }

    public DateTime? EffectiveDate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
