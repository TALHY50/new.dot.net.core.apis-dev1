using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class FpWalletTransactionEntity
{
    public int Id { get; set; }

    public string MerchantId { get; set; } = null!;

    public string? FpWalletUserCode { get; set; }

    public int? FpWalletMerchantId { get; set; }

    public int? FpWalletMerchantUserId { get; set; }

    public string OrderId { get; set; } = null!;

    public string WalletTransactionId { get; set; } = null!;

    public string? SaleId { get; set; }

    public double? WalletUserFee { get; set; }

    public int? PaymentSource { get; set; }

    public string? TrnCode { get; set; }

    public string? TrnCodeDetail { get; set; }

    public string? TrnCodeSpecial { get; set; }

    /// <summary>
    /// 0 =&gt; Not Processed,
    /// 1 =&gt; Processed Asynch
    /// 2 =&gt; Processed Wallet Event 
    /// </summary>
    public int Status { get; set; }

    /// <summary>
    /// Source/Name of the unitOfWork we are getting the response code from
    /// Values:
    /// walletCheck,
    /// walletApprove,
    /// walletNotify,
    /// walletCancel
    /// </summary>
    public string? FpWalletServiceSource { get; set; }

    /// <summary>
    /// Response code from FP wallet unitOfWork
    /// </summary>
    public string? FpWalletServiceResponseCode { get; set; }

    /// <summary>
    /// Response details from FP wallet unitOfWork
    /// </summary>
    public string? FpWalletServiceResponseDetails { get; set; }

    public double? CashbackAmount { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
