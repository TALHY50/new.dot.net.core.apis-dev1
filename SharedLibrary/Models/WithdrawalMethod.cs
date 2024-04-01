using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class WithdrawalMethod
{
    public uint Id { get; set; }

    public string Name { get; set; } = null!;

    public string Comment { get; set; } = null!;

    public double PercentageFee { get; set; }

    public double FixedFee { get; set; }

    public string? JsonData { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? BankName { get; set; }

    public string? AccountHolderName { get; set; }
}
