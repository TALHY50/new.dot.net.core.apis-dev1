using System;
using System.Collections.Generic;

namespace IMT.App.Domain.Entities;

public partial class MoneyTransfer
{
    public uint Id { get; set; }

    public string? PaymentId { get; set; }

    public uint? TransactionStateId { get; set; }

    public uint? ReasonId { get; set; }

    public uint? PaymentMethodId { get; set; }

    /// <summary>
    /// 1=regular, 2 = instant, 3 = same day
    /// </summary>
    public sbyte? TransferType { get; set; }

    public string? ReasonCode { get; set; }

    /// <summary>
    /// 1 = b2b, 2 = c2c, 3=c2b, 4=b2c 
    /// </summary>
    public sbyte? Type { get; set; }

    public string? SenderName { get; set; }

    public string? ReceiverName { get; set; }

    public uint? SenderCurrencyId { get; set; }

    public uint? ReceiverCurrencyId { get; set; }

    public decimal? ExchangeRate { get; set; }

    public decimal? SendAmount { get; set; }

    public decimal? ReceiveAmount { get; set; }

    public decimal? ExchangedAmount { get; set; }

    public decimal? Fee { get; set; }

    public decimal? Vat { get; set; }

    /// <summary>
    /// 1=paid by sender, 2=paid by receiver
    /// </summary>
    public sbyte? CommissionPaidBy { get; set; }

    public uint? SenderCustomerId { get; set; }

    public uint? ReceiverCustomerId { get; set; }

    /// <summary>
    /// 1=from api, 2= from admin
    /// </summary>
    public sbyte? Source { get; set; }

    public string? OrderId { get; set; }

    public string? RemoteOrderId { get; set; }

    public string? InvoiceId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
