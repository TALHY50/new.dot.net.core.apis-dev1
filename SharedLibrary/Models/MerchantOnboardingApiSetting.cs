using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class MerchantOnboardingApiSetting
{
    public int Id { get; set; }

    /// <summary>
    /// Understand that source ID is created for Merchant Name(like TestMerchantSipay)
    /// </summary>
    public string? SourceName { get; set; }

    /// <summary>
    /// random string for source
    /// </summary>
    public string SourceId { get; set; } = null!;

    /// <summary>
    /// 0 =&gt; inactive 1 =&gt; active
    /// </summary>
    public sbyte MerchantStatus { get; set; }

    /// <summary>
    /// merchant integrator id from existing list
    /// </summary>
    public int IntegratorId { get; set; }

    /// <summary>
    /// random 64 char+digit
    /// </summary>
    public string HashkeyPassword { get; set; } = null!;

    /// <summary>
    /// max number of merchants  can be  created daily  from a single source
    /// </summary>
    public sbyte MaxDailyCreation { get; set; }

    /// <summary>
    /// for stopping merchant use any balance before thay confirmed
    /// </summary>
    public double PosTransactionLimit { get; set; }

    /// <summary>
    /// same amount as pos_transaction_limit amount
    /// </summary>
    public double MerchantBlockAmount { get; set; }

    /// <summary>
    /// 1 =&gt; credit card , 2 =&gt; mobile payment , 3=&gt; wallet
    /// </summary>
    public sbyte PaymentMethods { get; set; }

    /// <summary>
    /// 0 =? now 3d user, 1 =&gt; 3d user
    /// </summary>
    public sbyte Is3d { get; set; }

    /// <summary>
    /// 0=2d, 1=3D, 2=Allow 2D And 3D
    /// </summary>
    public sbyte DplPosOption { get; set; }

    /// <summary>
    /// 0=2d, 1=3D, 2=Allow 2D And 3D
    /// </summary>
    public sbyte ManualPosOption { get; set; }

    /// <summary>
    /// 1=branded, 2 = white label
    /// </summary>
    public sbyte DplOption { get; set; }

    /// <summary>
    /// 0 =&gt; White Label 2D Only 1 =&gt; White Label 2D/3D, Allow User to Choose 2 =&gt; White Label 3D Only 4 =&gt; 2D/3D Branded Solution 8 =&gt; Redirected White Label
    /// </summary>
    public sbyte PaymentIntegrationOption { get; set; }

    /// <summary>
    /// 0 =&gt; no , 1 =&gt; yes
    /// </summary>
    public sbyte OtpRequiredToLogin { get; set; }

    /// <summary>
    /// 0 =&gt; not allowed, 1 =&gt; allowed
    /// </summary>
    public sbyte IsAllowForeignCards { get; set; }

    /// <summary>
    /// 0 =&gt; not allowed, 1 =&gt; allowed
    /// </summary>
    public sbyte CalculatePosByBank { get; set; }

    /// <summary>
    /// 0 =&gt; not allowed, 1 =&gt; allowed
    /// </summary>
    public sbyte IsAllowPayByToken { get; set; }

    /// <summary>
    /// 0 =&gt; not allowed, 1 =&gt; allowed
    /// </summary>
    public sbyte IsAllowB2cAutomation { get; set; }

    /// <summary>
    /// 0 =&gt; not allowed, 1 =&gt; allowed
    /// </summary>
    public sbyte IsAllowDpl { get; set; }

    /// <summary>
    /// 0 =&gt; not allowed, 1 =&gt; allowed
    /// </summary>
    public sbyte IsAllowManualPos { get; set; }

    /// <summary>
    /// 0 =&gt; not allowed, 1 =&gt; allowed
    /// </summary>
    public sbyte IsAllowOnePagePayment { get; set; }

    /// <summary>
    /// 0 =&gt; not allowed, 1 =&gt; allowed
    /// </summary>
    public sbyte IsAllowPreauthTransaction { get; set; }

    /// <summary>
    /// 0 =&gt; not allowed, 1 =&gt; allowed
    /// </summary>
    public sbyte IsAllowRecurringPayment { get; set; }

    /// <summary>
    /// 0 =&gt; not allowed, 1 =&gt; allowed
    /// </summary>
    public sbyte IsAllowB2cToWalletgate { get; set; }

    /// <summary>
    ///  1=&gt; daily, 2 =&gt; weekly friday, 3 =&gt;monthly, 11 =&gt; Weekly Wednesday , 18 =&gt; End of the Month
    /// </summary>
    public sbyte SettlementType { get; set; }

    /// <summary>
    /// 0 =&gt; not skipped , 1 =&gt; skipped
    /// </summary>
    public sbyte AllMandatoryDocs { get; set; }

    /// <summary>
    /// by default it will be system default currency id
    /// </summary>
    public int? CurrencyId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
