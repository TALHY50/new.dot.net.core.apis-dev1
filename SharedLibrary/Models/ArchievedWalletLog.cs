using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class ArchievedWalletLog
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string? EventName { get; set; }

    public string? EffectAmount { get; set; }

    public string? EffectWithdrawableAmount { get; set; }

    public string? EffectNonwithdrawableAmount { get; set; }

    public string? EffectRollingAmount { get; set; }

    public int CurrencyId { get; set; }

    public double BeforeAmount { get; set; }

    public double AfterAmount { get; set; }

    public double BeforeWithdrawableAmount { get; set; }

    public double AfterWithdrawableAmount { get; set; }

    public double BeforeNonwithdrawableAmount { get; set; }

    public double AfterNonwithdrawableAmount { get; set; }

    public double BeforeRollingAmount { get; set; }

    public double? AfterRollingAmount { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ActionName { get; set; }

    public string? BeforeLog { get; set; }

    public string? AfterLog { get; set; }

    public string? PaymentId { get; set; }

    public string? ReferenceType { get; set; }

    public int? ReferenceId { get; set; }

    public string? UniqueString { get; set; }

    public sbyte? MigrationStatus { get; set; }
}
