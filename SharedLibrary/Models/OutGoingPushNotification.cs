using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

/// <summary>
/// mobile app push notifications
/// </summary>
public partial class OutGoingPushNotification
{
    public int Id { get; set; }

    /// <summary>
    /// 1=&gt;single,2=&gt;multiple,3=&gt;group
    /// </summary>
    public bool? ReceiverType { get; set; }

    /// <summary>
    /// notification heading
    /// </summary>
    public string NotificationTitle { get; set; } = null!;

    /// <summary>
    /// notification body
    /// </summary>
    public string NotificationBody { get; set; } = null!;

    /// <summary>
    /// json encoded payload
    /// </summary>
    public string? Payload { get; set; }

    /// <summary>
    /// 1=&gt;low, 2=&gt;medium, 3=&gt;high, 4=&gt;express
    /// </summary>
    public bool? Priority { get; set; }

    /// <summary>
    /// 1=&gt;pending, 2=&gt;in progress, 3=&gt; successfully sent, 4=&gt;failed
    /// </summary>
    public sbyte Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
