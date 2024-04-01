using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class DuplicateTesting
{
    public int Id { get; set; }

    public string EventName { get; set; } = null!;

    public int WalletLogId { get; set; }

    public string DuplicateWalletIdList { get; set; } = null!;

    public int UserId { get; set; }

    public int CurrencyId { get; set; }

    public string EffectAmount { get; set; } = null!;

    public string EffectWithdrawableAmount { get; set; } = null!;

    public string EffectNonwithdrawableAmount { get; set; } = null!;

    public string EffectRollingAmount { get; set; } = null!;

    public DateTime? CreatedOn { get; set; }

    public double Total { get; set; }
}
