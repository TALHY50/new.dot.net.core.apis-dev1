using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class SaleAsynchronousProcess
{
    public int Id { get; set; }

    public int SaleId { get; set; }

    public int TransactionStateId { get; set; }

    public string Extras { get; set; } = null!;

    public string? SaleData { get; set; }

    public string BillingData { get; set; } = null!;

    public string SaleObj { get; set; } = null!;

    public string PurchaseRequestObj { get; set; } = null!;

    public string CurrencyObj { get; set; } = null!;

    public string? UserObj { get; set; }

    public string? DplObj { get; set; }

    public string? MerchantObj { get; set; }

    public string? MerchantSettingObj { get; set; }

    public string? PlanCode { get; set; }

    public sbyte IsLastRow { get; set; }

    public string? ActivityTitle { get; set; }

    /// <summary>
    /// 1= Auth, 2= PreAuth
    /// </summary>
    public sbyte? SaleType { get; set; }

    /// <summary>
    /// 0=not processed yet, 1=processed 2=notify about exception
    /// </summary>
    public sbyte Status { get; set; }

    public string? ExceptionMessage { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
