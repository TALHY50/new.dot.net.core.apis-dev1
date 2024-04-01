using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

/// <summary>
/// track push notifications read status
/// </summary>
public partial class UserPushNotification
{
    public int Id { get; set; }

    /// <summary>
    /// users primary key
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// out_going_push_notifications primary key
    /// </summary>
    public int OutGoingPushNotificationId { get; set; }

    /// <summary>
    /// 0=&gt;unread, 1=&gt;read
    /// </summary>
    public sbyte IsRead { get; set; }

    /// <summary>
    /// 1=&gt;pending, 2=&gt;in progress, 3=&gt; successfully sent, 4=&gt;failed
    /// </summary>
    public bool? Status { get; set; }
}
