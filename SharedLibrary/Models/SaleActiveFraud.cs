using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class SaleActiveFraud
{
    public int Id { get; set; }

    public string? InvoiceId { get; set; }

    public decimal? Score { get; set; }

    public double Severity { get; set; }

    /// <summary>
    /// fraud rule name
    /// </summary>
    public string? RuleName { get; set; }

    public int? MerchantId { get; set; }

    public decimal? Amount { get; set; }

    public int? CurrencyId { get; set; }

    /// <summary>
    /// card no stored with masking
    /// </summary>
    public string? CardNo { get; set; }

    public string? UserName { get; set; }

    public string? MerchantName { get; set; }

    /// <summary>
    /// requests inputs param except card info
    /// </summary>
    public string? RequestInputs { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
