using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class CardTokenRequest
{
    public int Id { get; set; }

    public string InvoiceId { get; set; } = null!;

    public string ParentInvoiceId { get; set; } = null!;

    public int MerchantId { get; set; }

    public int ParentMerchantId { get; set; }

    public string? MerchantKey { get; set; }

    public string? ParentMerchantKey { get; set; }

    public string? OrderId { get; set; }

    /// <summary>
    /// 0= not sent to bank yet. others will follow transaction_states table
    /// </summary>
    public sbyte? TransactionStateId { get; set; }

    public string ReturnUrl { get; set; } = null!;

    public string CancelUrl { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
