using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class MerchantBankCommission
{
    public int Id { get; set; }

    public int MerchantBankAccountsId { get; set; }

    public double? Min { get; set; }

    public double? Max { get; set; }

    public double? CommissionPercentage { get; set; }

    public double? CommissionFixed { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
