using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class PosBankCardBlackList
{
    public int Id { get; set; }

    public int PosId { get; set; }

    public int BankId { get; set; }

    public string? IssuerName { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
