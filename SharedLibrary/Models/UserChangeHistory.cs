using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class UserChangeHistory
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int? ProcessedBy { get; set; }

    public int? ApprovedBy { get; set; }

    public string OldValue { get; set; } = null!;

    public string NewValue { get; set; } = null!;

    /// <summary>
    /// 1=&gt;gsm, 2=&gt;email
    /// </summary>
    public sbyte Type { get; set; }

    /// <summary>
    /// 0=&gt;awaiting, 1=&gt; approved
    /// </summary>
    public sbyte Status { get; set; }

    public string Reason { get; set; } = null!;

    public string? CustomReason { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
