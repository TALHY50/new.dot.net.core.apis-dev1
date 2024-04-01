using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class UserAwaitingCategory
{
    public int Id { get; set; }

    public int? RequestedUserId { get; set; }

    public string? RequestedUserName { get; set; }

    public int? ActionBy { get; set; }

    public int? UserId { get; set; }

    public string? UserName { get; set; }

    public sbyte? FromCategory { get; set; }

    public sbyte? ToCategory { get; set; }

    public string? ContractedFile { get; set; }

    public string? RejectReason { get; set; }

    /// <summary>
    /// 0=&gt;pending, 1=&gt;approved, 2=&gt;rejected
    /// </summary>
    public sbyte? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
