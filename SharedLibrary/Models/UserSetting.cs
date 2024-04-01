using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class UserSetting
{
    public int Id { get; set; }

    public int UserId { get; set; }

    /// <summary>
    /// 0=disabled; 1=enabled
    /// </summary>
    public bool IsSmsEnable { get; set; }

    /// <summary>
    /// 0=disabled; 1=enabled
    /// </summary>
    public bool IsEmailEnable { get; set; }

    /// <summary>
    /// 0=&gt;disabled, 1=&gt;enabled
    /// </summary>
    public bool IsAppNotificationEnable { get; set; }

    public sbyte ActionName { get; set; }
}
