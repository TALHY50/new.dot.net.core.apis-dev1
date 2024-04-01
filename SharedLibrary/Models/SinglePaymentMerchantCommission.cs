using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class SinglePaymentMerchantCommission
{
    public int Id { get; set; }

    public int MerchantId { get; set; }

    public int CurrencyId { get; set; }

    /// <summary>
    /// 1 =&gt; Debit Card, 2 =&gt; Credit Card
    /// </summary>
    public sbyte CardType { get; set; }

    public double MerchantCommissionPercentage { get; set; }

    public double MerchantCommissionFixed { get; set; }

    public double EndUserCommissionPercentage { get; set; }

    public double EndUserCommissionFixed { get; set; }

    public int BankId { get; set; }

    public string IssuerName { get; set; } = null!;

    public int CreatedById { get; set; }

    public string CreatedByName { get; set; } = null!;

    public int UpdatedById { get; set; }

    public string UpdatedByName { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// 1 =&gt; Active, 2 =&gt; Inactive
    /// </summary>
    public sbyte Status { get; set; }

    public const int CARD_TYPE_DEBIT = 1;
    public const int CARD_TYPE_CREDIT = 2;

    public static readonly Dictionary<int,string> CARD_TYPES = new Dictionary<int, string> {
        { CARD_TYPE_DEBIT , "Debit Card" },
        { CARD_TYPE_CREDIT , "Credit Card" },
    };

    public const int STATUS_ACTIVE = 1;
    public const int STATUS_INACTIVE = 0;

    public static readonly Dictionary<int, string> STATUSES = new Dictionary<int, string> {
        { STATUS_ACTIVE , "Active" },
        { STATUS_INACTIVE , "Inactive" }
    };
}
