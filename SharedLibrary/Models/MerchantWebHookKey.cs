using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class MerchantWebHookKey
{
    
    public const int SALE_WEB_HOOK = 1;
    public const int RECURRING_WEB_HOOK = 2;
    public const int REFUND_WEB_HOOK = 3;
    public const int PF_WEB_HOOK = 4;
    
    public int Id { get; set; }

    public int MerchantId { get; set; }

    public string KeyName { get; set; } = null!;

    public string? Value { get; set; }

    /// <summary>
    /// &apos;1=sale webhook, 2=recurring webhook&apos;
    /// </summary>
    public sbyte Type { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
