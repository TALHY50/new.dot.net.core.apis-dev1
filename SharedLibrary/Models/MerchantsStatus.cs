using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class MerchantsStatus
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string? Vkn { get; set; }

    public string? Tckn { get; set; }

    /// <summary>
    /// 1 = blacklisted, 0 = not blacklisted
    /// </summary>
    public sbyte ResponseStatus { get; set; }

    public string? BlackReason { get; set; }

    public string? BlackListReason { get; set; }

    public DateTime CreatedAt { get; set; }
}
