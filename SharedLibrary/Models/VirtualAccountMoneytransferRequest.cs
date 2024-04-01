using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class VirtualAccountMoneytransferRequest
{
    public int Id { get; set; }

    /// <summary>
    /// merchants table primary key
    /// </summary>
    public int MerchantId { get; set; }

    /// <summary>
    /// merchant_virtual_account table primary key
    /// </summary>
    public int MerchantVirtualAccountWalletId { get; set; }

    /// <summary>
    /// unique transaction id to send to walletgate side for topup
    /// </summary>
    public string PaymentId { get; set; } = null!;

    /// <summary>
    /// sends table primary key
    /// </summary>
    public int? SendId { get; set; }

    /// <summary>
    /// money transfer amount
    /// </summary>
    public double Amount { get; set; }

    /// <summary>
    /// 0 = pending, 1 = completed, 2 = waiting for remove
    /// </summary>
    public sbyte Status { get; set; }

    /// <summary>
    /// any kind of description
    /// </summary>
    public string? Comment { get; set; }

    /// <summary>
    /// cron job process datetime
    /// </summary>
    public DateTime? ProcessedAt { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
