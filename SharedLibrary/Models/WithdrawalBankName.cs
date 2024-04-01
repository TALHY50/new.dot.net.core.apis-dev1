using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class WithdrawalBankName
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
