using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class MarketplaceSale
{
    public int Id { get; set; }

    public int MerchantId { get; set; }

    public string PaymentId { get; set; } = null!;

    public string GlobalInvoiceId { get; set; } = null!;

    public string GlobalOrderId { get; set; } = null!;

    public int CurrencyId { get; set; }

    public int TransactionStateId { get; set; }

    /// <summary>
    /// Summation of all product_price of each sale of marketplace
    /// </summary>
    public double? GlobalProductPrice { get; set; }

    public double GlobalGross { get; set; }

    public double GlobalNet { get; set; }

    public double GlobalMerchantShare { get; set; }

    public string MerchantName { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
