using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class ArchivedRequest
{
    public uint Id { get; set; }

    public int Attempts { get; set; }

    /// <summary>
    /// Merchant Id of a Merchant
    /// </summary>
    public int? MerchantId { get; set; }

    public string MerchantKey { get; set; } = null!;

    public string Ref { get; set; } = null!;

    public bool IsExpired { get; set; }

    /// <summary>
    /// For Duplicate Purchase Request
    /// 0 = No Duplicate
    /// 1 = Found Duplicate
    /// 2 = Cacnelled In Bank
    /// 3 = Tmp Refund Request Created
    /// </summary>
    public sbyte? IsDuplicateInvoice { get; set; }

    public string Data { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? CurrencyCode { get; set; }

    public int? CurrencyId { get; set; }

    public sbyte? MobilePaymentStatus { get; set; }

    public string? OrderId { get; set; }

    public string? InvoiceId { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Ip { get; set; }

    public string? Lang { get; set; }

    public sbyte? MigrationStatus { get; set; }
}
