using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class CurrencyWithdrawalMethod
{
    public uint Id { get; set; }

    public int? CurrencyId { get; set; }

    public int? WithdrawalMethodId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
