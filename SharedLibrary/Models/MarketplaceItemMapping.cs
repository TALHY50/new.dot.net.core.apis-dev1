using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class MarketplaceItemMapping
{
    public int Id { get; set; }

    /// <summary>
    /// id from master sales table
    /// </summary>
    public int SaleId { get; set; }

    public string GlobalOrderId { get; set; } = null!;

    public string GlobalInvoiceId { get; set; } = null!;

    public string OrderId { get; set; } = null!;

    public string InvoiceId { get; set; } = null!;

    public string ItemId { get; set; } = null!;

    /// <summary>
    /// To track the original single item_price for quantity based refund
    /// </summary>
    public double ItemUnitPrice { get; set; }

    public double ItemPrice { get; set; }

    /// <summary>
    /// Amount to settle after deducting rolling amount
    /// </summary>
    public double ItemAmount { get; set; }

    /// <summary>
    /// Rolling amount for a single item
    /// </summary>
    public double ItemRollingAmount { get; set; }

    public DateTime? ItemRollingSettlementDate { get; set; }

    public double ItemSubMerchantShare { get; set; }

    public double? RefundRequestedAmount { get; set; }

    public int? RefundHistoryId { get; set; }

    public double RefundedAmount { get; set; }

    /// <summary>
    /// 0 = Not Refunded
    /// 1 = Refunded
    /// </summary>
    public sbyte IsRefunded { get; set; }

    /// <summary>
    /// 0=Awaiting, 1 = Approved , Sale approval from marketplace merchant
    /// </summary>
    public sbyte? IsApproved { get; set; }

    /// <summary>
    /// To track the time of item approval via Merchant through TransactionApprove API
    /// </summary>
    public DateTime? ItemApprovedDate { get; set; }

    /// <summary>
    /// Status for settling item_amount to wallet withdrawable_balance
    /// 0 = Not Settled
    /// 1 = Settled
    /// </summary>
    public sbyte AmountSettlementStatus { get; set; }

    /// <summary>
    /// Status for settling item_rolling_amount to wallet withdrawable_balance
    /// 0 = Not Settled
    /// 1= Settled
    /// </summary>
    public sbyte RollingSettlementStatus { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
