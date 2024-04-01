using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class UserCurrenciesLimit
{
    public uint Id { get; set; }

    public int UserId { get; set; }

    public int CurrencyId { get; set; }

    public double CurrentMaxAllowValue { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
