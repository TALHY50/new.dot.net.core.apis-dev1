using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class SalesPfRecord
{
    public int Id { get; set; }

    public string? OrderId { get; set; }

    public string? PfMerchantId { get; set; }

    public string? MerchantId { get; set; }

    public string? PfMerchantName { get; set; }

    public string? SubMerchantId { get; set; }

    public string? IdentityNin { get; set; }

    /// <summary>
    /// Identity number from Insurance Payment / Pay By TCKN
    /// </summary>
    public string? ClientIdentityNumber { get; set; }

    /// <summary>
    /// mcc
    /// </summary>
    public string? Mcc { get; set; }

    /// <summary>
    /// 1 = older than 8th nov 2022, 
    /// 2= new after this date
    /// </summary>
    public sbyte? Version { get; set; }

    /// <summary>
    /// 0=not landend for same order id, 1= already landed for same order id
    /// </summary>
    public sbyte? BankLandingStatus { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
