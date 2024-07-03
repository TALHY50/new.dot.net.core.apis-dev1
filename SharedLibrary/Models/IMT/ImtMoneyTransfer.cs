using System;
using System.Collections.Generic;

namespace SharedLibrary.Models.IMT;

public partial class ImtMoneyTransfer
{
    public int Id { get; set; }

    public string? PaymentId { get; set; }

    public int? TransactionStateId { get; set; }

    public int? ReasonId { get; set; }

    public int? PaymentMethodId { get; set; }

    /// <summary>
    /// 1=instant, 2=regular, 3=same_day etc.
    /// </summary>
    public sbyte? TransferType { get; set; }

    public string? ReasonCode { get; set; }

    /// <summary>
    /// type 1 = b2b, 2 = c2c, 3=c2b, 4=b2c etc
    /// </summary>
    public sbyte? Type { get; set; }

    public string? SenderName { get; set; }

    public string? ReceiverName { get; set; }

    public int? SenderCurrencyId { get; set; }

    public int? ReceiverCurrencyId { get; set; }

    public decimal? ExchangeRate { get; set; }

    public decimal? SendAmount { get; set; }

    public decimal? ReceiveAmount { get; set; }

    public decimal? ExchangedAmount { get; set; }

    public decimal? Fee { get; set; }

    public decimal? Vat { get; set; }

    public string? CommissionPaidBy { get; set; }

    public int? SenderCustomerId { get; set; }

    public int? ReceiverCustomerId { get; set; }

    public string? Source { get; set; }

    public string? OrderId { get; set; }

    public string? RemoteOrderId { get; set; }

    public string? InvoiceId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
