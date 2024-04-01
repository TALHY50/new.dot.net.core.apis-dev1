using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class MerchantAutomaticWithdrawalSetting
{
    public int Id { get; set; }

    public int MerchantId { get; set; }

    public int UserId { get; set; }

    public double Amount { get; set; }

    public int AutomaticWithdrawMerchantBankId { get; set; }

    public string SettlementType { get; set; } = null!;

    public string? SettlementValue { get; set; }

    public DateTime? ProcessDate { get; set; }

    /// <summary>
    /// 1=automatic, 0=no
    /// </summary>
    public sbyte? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
