using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class MarketplaceSaleMapping
{
    public int Id { get; set; }

    public int SaleId { get; set; }

    public int MerchantId { get; set; }

    /// <summary>
    /// Sub merchant under a Merchant
    /// </summary>
    public string SubMerchantId { get; set; } = null!;

    /// <summary>
    /// Sub Merchant Order ID from Global Order ID
    /// </summary>
    public string OrderId { get; set; } = null!;

    /// <summary>
    /// Sub Merchant Invoice ID from Global Invoice ID
    /// </summary>
    public string InvoiceId { get; set; } = null!;

    /// <summary>
    /// Original Invoice ID from Request
    /// </summary>
    public string GlobalInvoiceId { get; set; } = null!;

    /// <summary>
    /// Original Order ID of a Sale
    /// </summary>
    public string GlobalOrderId { get; set; } = null!;

    /// <summary>
    /// Total share from a sale
    /// </summary>
    public double? SubMerchantShare { get; set; }

    /// <summary>
    /// Total share from a sale
    /// </summary>
    public double? MerchantShare { get; set; }

    /// <summary>
    /// Sub Merchant settlement date from the settlement id in Marketplace payment request
    /// </summary>
    public DateTime SubMerchantSettlementDate { get; set; }

    /// <summary>
    /// In case merchant fails to aprove an item for settlement via TransactionApprove API on this date item will be auto approved for settlement
    /// </summary>
    public DateTime? SubMerchantSettlementAutoApprovalDate { get; set; }
}
