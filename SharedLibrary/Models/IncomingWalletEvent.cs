using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class IncomingWalletEvent
{
    public int Id { get; set; }

    public string OrderId { get; set; } = null!;

    public int SaleId { get; set; }

    public double? DebitAmount { get; set; }

    public double? CreditAmount { get; set; }

    public int CurrencyId { get; set; }

    public int UserId { get; set; }

    public string Type { get; set; } = null!;

    public string PaymentId { get; set; } = null!;

    public string EventName { get; set; } = null!;

    public string ReferenceId { get; set; } = null!;

    public string TransactionType { get; set; } = null!;

    /// <summary>
    /// 1=already processed, 0=Not Process yet
    /// </summary>
    public sbyte? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
