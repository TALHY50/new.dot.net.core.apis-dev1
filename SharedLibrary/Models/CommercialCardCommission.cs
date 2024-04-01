using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class CommercialCardCommission
{
    public uint Id { get; set; }

    public int CurrencyId { get; set; }

    /// <summary>
    /// Card program
    /// </summary>
    public string? Program { get; set; }

    public sbyte InstallmentNumber { get; set; }

    public int MerchantId { get; set; }

    public double? MerchantComPercentage { get; set; }

    public double? MerchantComFixed { get; set; }

    public double EndUserComPercentage { get; set; }

    public double? EndUserComFixed { get; set; }

    /// <summary>
    /// 0 = Inactive, 1 = Active
    /// </summary>
    public sbyte Status { get; set; }

    /// <summary>
    /// admin id
    /// </summary>
    public int? CreatedById { get; set; }

    /// <summary>
    /// admin id
    /// </summary>
    public int? UpdatedById { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
    public const bool STATUS_ACTIVE = true;
    public const bool STATUS_INACTIVE = false;
}
