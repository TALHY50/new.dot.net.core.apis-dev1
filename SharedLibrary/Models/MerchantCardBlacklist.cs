using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class MerchantCardBlacklist
{
    public int Id { get; set; }

    /// <summary>
    /// &apos;1=visa, 2=mastercard, 3=amex, 4=diners, 5=discover, 6=jcb, 7=any&apos;
    /// </summary>
    public int MerchantId { get; set; }

    public sbyte CardType { get; set; }

    public int FromStartWith { get; set; }

    public int? ToStartWith { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
