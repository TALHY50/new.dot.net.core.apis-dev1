using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class TmpPo
{
    public int Id { get; set; }

    public int? PosId { get; set; }

    public string? VirtualPosId { get; set; }

    public string? Name { get; set; }

    public sbyte SettlementId { get; set; }

    public sbyte RefundSettlementId { get; set; }

    public sbyte ForeignCardSettlementId { get; set; }

    public int? BankId { get; set; }

    public string? BankName { get; set; }

    public double OnUsCcCotPercentage { get; set; }

    public double OnUsCcCotFixed { get; set; }

    public double NotUsCcCotPercentage { get; set; }

    public double NotUsCcCotFixed { get; set; }

    public double DebitCotPercentage { get; set; }

    public double DebitCotFixed { get; set; }

    public double NotUsDebitCotPercentage { get; set; }

    public double NotUsDebitCotFixed { get; set; }

    public double? ForeignCcCotPercentage { get; set; }

    public double? ForeignCcCotFixed { get; set; }

    public double? ForeignAmexCotPercentage { get; set; }

    public double? ForeignAmexCotFixed { get; set; }

    public double? LocalAmexCotPercentage { get; set; }

    public double? LocalAmexCotFixed { get; set; }

    public double? SameProgramSameBankCotPercentage { get; set; }

    public double? SameProgramSameBankCotFixed { get; set; }

    public double? SameProgramDiffrentBankCotPercentage { get; set; }

    public double? SameProgramDiffrentBankCotFixed { get; set; }

    public sbyte? CurrencyId { get; set; }

    public sbyte MinInstallment { get; set; }

    public sbyte MaxInstallment { get; set; }

    public string? Program { get; set; }

    public sbyte Bolum { get; set; }

    /// <summary>
    /// 1 = active, 0 = inactive
    /// </summary>
    public sbyte Status { get; set; }

    public DateTime? EffectDate { get; set; }

    /// <summary>
    /// 0 = not processed by cron, 1 = already processed by cron
    /// </summary>
    public sbyte EffectStatus { get; set; }

    /// <summary>
    /// 0 = dont send, 1 = send
    /// </summary>
    public sbyte? SendPfRecords { get; set; }

    /// <summary>
    /// 1=enable; 0=disable
    /// </summary>
    public sbyte? IsEnable2d { get; set; }

    /// <summary>
    /// 1=enable; 0=disable
    /// </summary>
    public sbyte? IsEnable3d { get; set; }

    /// <summary>
    /// 0 =allow_foreign_card inactive; 1= allow_foreign_card active
    /// </summary>
    public sbyte? AllowForeignCard { get; set; }

    /// <summary>
    /// 0 = not  allow,  1=allow
    /// </summary>
    public sbyte? IsAllowDcc { get; set; }

    /// <summary>
    /// 0 = not  allow,  1=allow
    /// </summary>
    public sbyte? IsAllowLocalAmexCard { get; set; }

    /// <summary>
    /// 0 = not  allow,  1=allow
    /// </summary>
    public sbyte? IsAllowForeignAmexCard { get; set; }

    public sbyte? IsRecurring { get; set; }

    public sbyte? IsShowOnDeposit { get; set; }

    public sbyte? IsAllowSale { get; set; }

    /// <summary>
    /// To check if POS is allowed for insurance payment
    /// 0 : Not Allowed
    /// 1 : Allowed
    /// </summary>
    public sbyte? IsAllowInsurancePayment { get; set; }

    /// <summary>
    /// To check if POS is allowed for installment wise settlement
    /// 0 : Not Allowed
    /// 1 : Allowed
    /// </summary>
    public sbyte? IsInstallmentWiseSettlement { get; set; }

    /// <summary>
    /// 0 = auth ; 1 = pre_auth
    /// </summary>
    public sbyte? IsAllowPreAuth { get; set; }

    public sbyte? AllowPayByCardToken { get; set; }

    public string? RemoteSubMerchantId { get; set; }

    public int MaxNoOfFailedAttempt { get; set; }

    public int? CreatedById { get; set; }

    public int? UpdatedById { get; set; }

    public TimeOnly? BankClosingTime { get; set; }

    /// <summary>
    /// id from brand_bank_accounts table where pos account is true
    /// </summary>
    public int? BrandBankAccountId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
