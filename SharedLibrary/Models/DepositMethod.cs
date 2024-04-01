using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class DepositMethod
{
    public uint Id { get; set; }

    public string Name { get; set; } = null!;

    public string? HowTo { get; set; }

    public string? JsonData { get; set; }

    /// <summary>
    /// 1=&gt;active;0=&gt;inactive
    /// </summary>
    public sbyte Status { get; set; }

    /// <summary>
    /// 0=no; 1=yes
    /// </summary>
    public sbyte IsShownInCustomer { get; set; }

    /// <summary>
    /// 0=no; 1=yes
    /// </summary>
    public sbyte IsShownInMerchant { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
    public const int DEPOSIT_METHOD_ACTIVE = 1;
    public const int DEPOSIT_METHOD_INACTIVE = 2;
    public const string PAYMENT_TYPE_SIPAY = "Havale";
    public const int EFT = 4;
    public const int CREDIT_CARD = 5;
    public const int CREDIT_CARD_FORM = 6;
    public const int SIPAY_BANK = 7;
    public const int FAST = 8;
}
