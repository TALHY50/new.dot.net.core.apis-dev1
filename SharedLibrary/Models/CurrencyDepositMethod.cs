using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class CurrencyDepositMethod
{
    public uint Id { get; set; }

    public int? CurrencyId { get; set; }

    public int? DepositMethodId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
