using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class AwaitingRequest
{
    public int Id { get; set; }

    public int RequestedUserId { get; set; }

    public int UserId { get; set; }

    public int ActionBy { get; set; }

    public string Name { get; set; } = null!;

    public string TableName { get; set; } = null!;

    public string RejectReason { get; set; } = null!;

    public string FilePath { get; set; } = null!;

    /// <summary>
    /// 0=&gt;pending;1=&gt;approved;2=&gt;rejected;
    /// </summary>
    public sbyte Status { get; set; }

    /// <summary>
    /// for keeping filter params while export
    /// </summary>
    public string? JsonData { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
