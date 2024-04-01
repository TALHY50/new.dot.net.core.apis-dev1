using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class SalesSettlement
{
    public int Id { get; set; }

    public int SaleId { get; set; }

    public string OrderId { get; set; } = null!;

    public int MerchantId { get; set; }

    public sbyte? CurrencyId { get; set; }

    /// <summary>
    /// 1st, 2nd, 3rd ... nth installment
    /// </summary>
    public int InstallmentsNumber { get; set; }

    public double? Gross { get; set; }

    public double? SettledAmount { get; set; }

    public double? MerchantCommission { get; set; }

    /// <summary>
    /// merchant net divided by installments_number
    /// </summary>
    public double NetSettlement { get; set; }

    public DateTime SettlementDateBank { get; set; }

    public DateTime SettlementDateMerchant { get; set; }

    /// <summary>
    /// refund request amount from refund
    /// </summary>
    public double? RefundRequestAmount { get; set; }

    /// <summary>
    /// refunded amount from a refund
    /// </summary>
    public double? RefundedAmount { get; set; }

    /// <summary>
    /// id from refund_histories
    /// </summary>
    public int? RefundHistoryId { get; set; }

    /// <summary>
    /// indicates whether this indicates whether this settlement is fully refunded
    /// </summary>
    public bool? IsFullyRefunded { get; set; }

    /// <summary>
    /// 0 = not settled, 1 = Settled
    /// </summary>
    public bool Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
