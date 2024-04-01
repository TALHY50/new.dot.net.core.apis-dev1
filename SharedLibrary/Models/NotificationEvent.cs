using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class NotificationEvent
{
    public int Id { get; set; }

    /// <summary>
    /// 1=Payment link success, 2=Payment link failed, 3=Manual pos success, 4=Manual pos failed, 5=API transaction success , 6=API transaction failed
    /// </summary>
    public int EventId { get; set; }

    /// <summary>
    /// id from merchant table
    /// </summary>
    public int MerchantId { get; set; }

    /// <summary>
    /// id from user table
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Receivers email or phone number list
    /// </summary>
    public string? Receivers { get; set; }

    /// <summary>
    /// 1 = email, 2 = SMS, 3 = Push notification
    /// </summary>
    public sbyte NotificationType { get; set; }

    /// <summary>
    /// 0=&gt;customer; 1=&gt;admin; 2=&gt;merchant; 3=&gt;submerchant
    /// </summary>
    public bool UserType { get; set; }

    /// <summary>
    /// 1 = Active 0 = Inactive
    /// </summary>
    public bool? Status { get; set; }

    public int CreatedById { get; set; }

    public int UpdatedById { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
