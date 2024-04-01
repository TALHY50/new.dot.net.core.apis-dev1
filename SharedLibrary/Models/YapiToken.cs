using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class YapiToken
{
    public uint Id { get; set; }

    public int MerchantId { get; set; }

    public double Gross { get; set; }

    public string CurrencyCode { get; set; } = null!;

    public string TerminalNo { get; set; } = null!;

    public string Token { get; set; } = null!;

    /// <summary>
    /// 0 = Not Processed Yet, 1 = Processed
    /// </summary>
    public sbyte Status { get; set; }

    public string InvoiceId { get; set; } = null!;

    public string OrderId { get; set; } = null!;

    public string Data { get; set; } = null!;

    public double? TotalCommission { get; set; }

    public double? SubMerchantShare { get; set; }

    public double? YkbShare { get; set; }

    public double? TaxiShare { get; set; }

    public double? BrandShare { get; set; }

    public double? IntegratorShare { get; set; }

    public double? MerchantShare { get; set; }

    public DateTime ExpiredOn { get; set; }

    public string? ReferenceNo { get; set; }

    public string? ErrorCode { get; set; }

    public string? ErrorMessage { get; set; }

    public int? Attempt { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
