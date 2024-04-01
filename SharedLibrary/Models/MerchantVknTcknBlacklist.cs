using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class MerchantVknTcknBlacklist
{
    public int Id { get; set; }

    public string? Vkn { get; set; }

    public string? Tckn { get; set; }

    public string? BlackListReason { get; set; }

    /// <summary>
    /// 1 = active, 0 = inactive
    /// </summary>
    public sbyte Status { get; set; }

    /// <summary>
    /// user id of who created
    /// </summary>
    public int? CreatedBy { get; set; }

    public string? CreatedByName { get; set; }

    /// <summary>
    /// user id of who modified
    /// </summary>
    public int? UpdatedBy { get; set; }

    /// <summary>
    /// modified by name
    /// </summary>
    public string? UpdatedByName { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
