using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class CurrencyExchangeRate
{
    public uint Id { get; set; }

    public int FirstCurrencyId { get; set; }

    public int SecondCurrencyId { get; set; }

    public double ExchangesToSecondCurrencyValue { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
