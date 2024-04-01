using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class UserAnnouncement
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? AnnouncementId { get; set; }

    /// <summary>
    /// 0=&gt;unread, 1=&gt;read
    /// </summary>
    public bool IsRead { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
