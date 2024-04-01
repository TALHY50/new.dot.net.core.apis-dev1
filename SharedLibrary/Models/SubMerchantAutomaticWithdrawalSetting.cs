using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class SubMerchantAutomaticWithdrawalSetting
{
    public int Id { get; set; }

    public int SubMerchantId { get; set; }

    /// <summary>
    /// Auto Withdrawal settlement id for the submerchant
    /// </summary>
    public int? SettlementId { get; set; }

    /// <summary>
    /// Auto Withdrawal currency id
    /// </summary>
    public sbyte? CurrencyId { get; set; }

    /// <summary>
    /// Auto Withdrawal remain amount for the submerchant
    /// </summary>
    public double? RemainAmount { get; set; }

    /// <summary>
    /// last processed date of Auto Withdrawal
    /// </summary>
    public DateTime? LastProcessedAt { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
