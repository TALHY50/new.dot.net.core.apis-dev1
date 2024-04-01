using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class RefundHistory
{
    public const int TYPE_REFUND = 1;
    public const int TYPE_CHARGEBACK = 2;
    
    public const sbyte REFUND_TO_WALLET = 1;
    public const sbyte REFUND_TO_BANK = 2;

    public const sbyte IS_APPROVED_TRIGGERED = 1;
  
    
    public int Id { get; set; }

    public int TransactionStateId { get; set; }

    public int TransactionableId { get; set; }

    public string TransactionableType { get; set; } = null!;

    public int SaleId { get; set; }

    public int MerchantId { get; set; }

    public int CurrencyId { get; set; }

    public double Amount { get; set; }

    public double NetRefundAmount { get; set; }

    public double RollingRefundAmount { get; set; }

    public int? AdminActionBy { get; set;}
    
    public string? ApprovedBy { get; set;}

    public DateTime? AdminActionDate { get; set; }

    public DateTime? RefundBankSettlementDate { get; set; }

    public int? EndUserId { get; set; }

    /// <summary>
    /// 1=&gt;refund to Wallet, 2=&gt; refund to Bank
    /// </summary>
    public sbyte? RefundTo { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// This is not a percentage value but percentage amount without fixed amount
    /// </summary>
    public double? RefundCommission { get; set; }

    public double? RefundCommissionFixed { get; set; }

    public string? RefundFeeWallet { get; set; }

    /// <summary>
    /// 1=withdrawable , 2 -  non-withdrrawable
    /// </summary>
    public sbyte? WalletSource { get; set; }

    public string? RefundReferenceNumber { get; set; }

    /// <summary>
    /// 1= refund, 2= chargeback
    /// </summary>
    public sbyte? RefundType { get; set; }

    public string? RefundTransactionId { get; set; }

    public int? RequestedBy { get; set; }

    /// <summary>
    /// 1= admin, 2=merchant 3=api
    /// </summary>
    public sbyte? Source { get; set; }

    public sbyte? IsFullyRefunded { get; set; }

    public string? UniqueString { get; set; }

    /// <summary>
    /// store auth code which is provided by bank while refund
    /// </summary>
    public string? RefundAuthCode { get; set; }

    /// <summary>
    /// 0=not approved yet, 1=refund is approved
    /// </summary>
    public sbyte? IsApproveTriggered { get; set; }

    public string? OriginalBankErrorCode { get; set; }

    public string? OriginalBankErrorDescription { get; set; }
}
