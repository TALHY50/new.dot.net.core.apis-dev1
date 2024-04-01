using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class RequestMoney
{
    public int Id { get; set; }

    public string? PaymentId { get; set; }

    /// <summary>
    /// receiver user id
    /// </summary>
    public int ReceiverId { get; set; }

    /// <summary>
    /// sender user id
    /// </summary>
    public int SenderId { get; set; }

    /// <summary>
    /// transactionstate table id
    /// </summary>
    public sbyte Status { get; set; }

    public string? ReceiverPhone { get; set; }

    public string? SenderPhone { get; set; }

    public string? ReceiverName { get; set; }

    public string? SenderName { get; set; }

    public string? SenderRegion { get; set; }

    public string? ReceiverRegion { get; set; }

    public double Amount { get; set; }

    public double? Commission { get; set; }

    public sbyte CurrencyId { get; set; }

    public string? CurrecnySymbol { get; set; }

    public string? CurrencyCode { get; set; }

    public string? Explanation { get; set; }

    /// <summary>
    /// unique url for split account
    /// </summary>
    public string? UniqueSplitUrl { get; set; }

    /// <summary>
    /// split account table primary id
    /// </summary>
    public int? SplitAccountId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? ProcessDate { get; set; }

    /// <summary>
    /// 0=all request money; 1=request money via split account
    /// </summary>
    public sbyte? Type { get; set; }
}
