using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class MerchantSale
{
    public const sbyte AWAITING =0;
    public const sbyte PROCESSED = 1;

    public int Id { get; set; }

    public int MerchantId { get; set; }

    public int UserId { get; set; }

    public int SaleId { get; set; }

    public double Amount { get; set; }

    public double? MerchantCommissionPercentage { get; set; }

    public double? MerchantCommissionFixed { get; set; }

    public double? CotPercentage { get; set; }

    public double? CotFixed { get; set; }

    public double MerchantRollingPercentage { get; set; }

    public double? EndUserCommissionPercentage { get; set; }

    public double? EndUserCommissionFixed { get; set; }

    public double RefundRequestAmount { get; set; }

    public int CurrencyId { get; set; }

    public sbyte SettlementId { get; set; }

    /// <summary>
    /// 0=&gt;Awaiting, 1=&gt;Processed
    /// </summary>
    public sbyte Status { get; set; }

    /// <summary>
    /// 1=&gt; Credit Card, 2= Debit Card
    /// </summary>
    public sbyte CardType { get; set; }

    public DateTime? EffectiveDate { get; set; }

    public DateTime? NextEffectiveDate { get; set; }

    public DateTime? ReportingSettlementDate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public double? RefundCommission { get; set; }

    public double? RefundCommissionFixed { get; set; }

    public double? ChargebackCommission { get; set; }

    public double? ChargebackCommissionFixed { get; set; }

    public double? PayByTokenCommission { get; set; }

    public double? PayByTokenFixed { get; set; }

    /// <summary>
    /// 0=&gt;No Refund, 1=&gt;Refund
    /// </summary>
    public sbyte? IsPayByTokenRefundChecked { get; set; }
}
