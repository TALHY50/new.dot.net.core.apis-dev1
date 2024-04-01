using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class UserDevice
{
    public ulong Id { get; set; }

    public ulong UserId { get; set; }

    public string? DeviceName { get; set; }

    public string? DeviceBrand { get; set; }

    public string? FirstConnectionIp { get; set; }

    public string? NetworkOperator { get; set; }

    public string? SystemVersion { get; set; }

    public string? UserAgent { get; set; }

    /// <summary>
    /// 0=&gt;false, 1=&gt;true
    /// </summary>
    public bool? IsTablet { get; set; }

    public string? PushNotificationKey { get; set; }

    public string? HuaweiPushNotificationKey { get; set; }

    public string? ApnsToken { get; set; }

    /// <summary>
    /// 0=&gt;false, 1=&gt;true
    /// </summary>
    public bool? IsActive { get; set; }

    public string? AppUniqueKey { get; set; }

    public DateTime? DeletedAt { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
