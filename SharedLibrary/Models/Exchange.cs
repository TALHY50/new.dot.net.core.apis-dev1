using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class Exchange
{
    public uint Id { get; set; }

    public string? PaymentId { get; set; }

    public int? UserId { get; set; }

    public int? FirstCurrencyId { get; set; }

    public int? SecondCurrencyId { get; set; }

    public double? Gross { get; set; }

    public double? Fee { get; set; }

    public double? Net { get; set; }

    public double? Cost { get; set; }

    public double? FromAmount { get; set; }

    public double? ToAmount { get; set; }

    public double? ExchangeRate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? Name { get; set; }

    public string? GsmNumber { get; set; }

    public sbyte UserType { get; set; }
}
