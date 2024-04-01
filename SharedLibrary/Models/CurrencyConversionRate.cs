using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class CurrencyConversionRate
{
    public string Id { get; set; } = null!;

    public string FromCurrencyCode { get; set; } = null!;

    public string ToCurrencyCode { get; set; } = null!;

    public double Rate { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
