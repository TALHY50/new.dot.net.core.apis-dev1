using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class TmpRefundRequest
{
    public int Id { get; set; }

    /// <summary>
    /// type of refund,
    /// 1 = refund
    /// 2 = chargeback
    /// 3 = retry awaiting refund
    /// </summary>
    public sbyte? Type { get; set; }

    /// <summary>
    /// Priority of refunds
    /// 1 = express
    /// 
    /// 2 = high
    /// 
    /// 3 = medium
    /// 
    /// 4= low
    /// </summary>
    public sbyte? Priority { get; set; }

    public string MerchantId { get; set; } = null!;

    public string? MerchantKey { get; set; }

    public int MerchantUserId { get; set; }

    public int SaleId { get; set; }

    public string OrderId { get; set; } = null!;

    public string InvoiceId { get; set; } = null!;

    public string UniqueId { get; set; } = null!;

    public string RefundTransactionId { get; set; } = null!;

    public double ProductPrice { get; set; }

    public double Amount { get; set; }

    public string? RefundWebHookKey { get; set; }

    /// <summary>
    /// 1 - From Api
    /// 2 - From FP
    /// 3 - From Paybill
    /// 4 - From Pavo
    /// 5 - From Duplicate Invoice
    /// </summary>
    public sbyte Source { get; set; }

    /// <summary>
    /// 1 = Refund to Wallet, 2 = Refund to Bank
    /// </summary>
    public sbyte? RefundType { get; set; }

    /// <summary>
    /// 0 = Not Processed Yet
    /// 1 = Processed
    /// </summary>
    public int Status { get; set; }

    public int? StatusCode { get; set; }

    public string? StatusDescription { get; set; }

    /// <summary>
    /// This reference number is prvided by bank. And it is store when manually bulk refund. 
    /// </summary>
    public string? RefundReferenceNumber { get; set; }

    /// <summary>
    /// Field to control frequency of immediate refund request
    /// </summary>
    public sbyte? Attempt { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
