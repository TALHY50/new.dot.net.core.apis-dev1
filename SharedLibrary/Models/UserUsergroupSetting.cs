using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class UserUsergroupSetting
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public sbyte IsAllowDirectExport { get; set; }

    public sbyte IsAllowB2bWithoutDoc { get; set; }

    /// <summary>
    /// 1=allowed, 0=not allowed
    /// </summary>
    public sbyte IsAllowCreateDeposit { get; set; }

    /// <summary>
    /// 1=allowed, 0=not allowed
    /// </summary>
    public sbyte IsAllowCreateWithdrawal { get; set; }

    /// <summary>
    /// 1=allowed, 0=not allowed
    /// </summary>
    public sbyte IsAllowCreateB2b { get; set; }

    /// <summary>
    /// 1=allowed, 0=not allowed
    /// </summary>
    public sbyte IsAllowCreateB2c { get; set; }

    /// <summary>
    /// 1=allowed, 0=not allowed
    /// </summary>
    public sbyte IsShowAuthEmail { get; set; }

    /// <summary>
    /// 1=show, 0=hide
    /// </summary>
    public sbyte IsShowWebsite { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
