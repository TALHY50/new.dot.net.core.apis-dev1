using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class TmpMerchantHashKey
{
    public int Id { get; set; }

    public int MerchantId { get; set; }

    public string? Name { get; set; }

    public string? AuthEmail { get; set; }

    public string? AuthPhone { get; set; }

    public string? RequestUrl { get; set; }

    /// <summary>
    /// pavo successful transactions acquirerBKMCode for sending alert email
    /// </summary>
    public string? BankCode { get; set; }

    /// <summary>
    /// 0 =&gt; hash key alert , 1 =&gt; imported transaction ( pavo ) alert
    /// </summary>
    public sbyte Type { get; set; }

    public DateTime? LastActionDate { get; set; }
    public const int NEW_MERCHANT = 1;
    public const int TYPE_IMPORTED_TRANSACTION = 1;
}
