using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class UserViewedNotification
{
    public int Id { get; set; }

    public Guid NotificationId { get; set; }

    public int UserId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
