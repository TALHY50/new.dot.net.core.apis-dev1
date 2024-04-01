using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class UserLoginAlertSetting
{
    public int Id { get; set; }

    /// <summary>
    /// 0=Customer, 1=Admin, 2 = Merchant
    /// </summary>
    public sbyte? UserType { get; set; }

    public TimeOnly? FromTime { get; set; }

    public TimeOnly? ToTime { get; set; }

    /// <summary>
    /// 1=active, 0=inactive
    /// </summary>
    public sbyte? IsNotificationTypeSms { get; set; }

    /// <summary>
    /// 1=active, 0=inactive
    /// </summary>
    public sbyte? IsNotificationTypeEmail { get; set; }

    public string? EmailAddresses { get; set; }

    public string? SmsNumbers { get; set; }

    /// <summary>
    /// 1=active, 0=inactive
    /// </summary>
    public sbyte? Status { get; set; }

    public int? CreatedByUserId { get; set; }

    public int? UpdatedByUserId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
