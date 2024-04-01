using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class CurrencyExchangeCommission
{
    public int Id { get; set; }

    public int FromCurrencyId { get; set; }

    public int ToCurrencyId { get; set; }

    public double CommissionPercentage { get; set; }

    public double CommissionAmount { get; set; }
}
