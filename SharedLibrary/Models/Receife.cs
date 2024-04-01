using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class Receife
{
    public uint Id { get; set; }

    public string? PaymentId { get; set; }

    public int UserId { get; set; }

    public string? UserName { get; set; }

    public int? SenderMerchantId { get; set; }

    public string? SenderMerchantName { get; set; }

    public string? UserGsmNumber { get; set; }

    public int SendId { get; set; }

    public int FromId { get; set; }

    public string? FromName { get; set; }

    public string? FromGsmNumber { get; set; }

    public int TransactionStateId { get; set; }

    public double? Gross { get; set; }

    public double? Fee { get; set; }

    public double? Net { get; set; }

    public double? Cost { get; set; }

    public string? Description { get; set; }

    public string? JsonData { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? CurrencyId { get; set; }

    public string? CurrencySymbol { get; set; }

    public sbyte? Type { get; set; }
}
