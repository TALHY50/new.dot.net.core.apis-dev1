using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class WithdrawalSavedAccount
{
    public uint Id { get; set; }

    public int WithdrawBankId { get; set; }

    public string? AccountHolder { get; set; }

    public string? AccountNumber { get; set; }

    public string? SwiftCode { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
