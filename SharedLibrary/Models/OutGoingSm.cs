using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class OutGoingSm
{
    public int Id { get; set; }

    /// <summary>
    /// to phone number
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// message body
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    /// 1=low, 2=medium, 3=high, 4=express
    /// </summary>
    public sbyte? Priority { get; set; }

    /// <summary>
    /// header data
    /// </summary>
    public string? Header { get; set; }

    /// <summary>
    /// 1=pending, 2=in progress, 3=successfully sent, 4=failed
    /// </summary>
    public sbyte? Status { get; set; }

    /// <summary>
    /// sms sending exception
    /// </summary>
    public string? Note { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
