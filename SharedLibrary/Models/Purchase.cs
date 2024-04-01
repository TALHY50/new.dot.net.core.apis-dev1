using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class Purchase
{
    public uint Id { get; set; }

    public int UserId { get; set; }

    public string? OrderId { get; set; }

    public int MerchantId { get; set; }

    public int TransactionStateId { get; set; }

    public int SaleId { get; set; }

    /// <summary>
    /// 1=&gt;credit_card, 2=&gt;Mobile, 3=&gt;Wallet
    /// </summary>
    public sbyte? PaymentTypeId { get; set; }

    public double? Gross { get; set; }

    public double? Fee { get; set; }

    public double? Net { get; set; }

    public string? JsonData { get; set; }

    public string? RefundReason { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? CurrencyId { get; set; }

    public string? CurrencySymbol { get; set; }
}
