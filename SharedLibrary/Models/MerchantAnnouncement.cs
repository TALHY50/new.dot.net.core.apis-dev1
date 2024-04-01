using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class MerchantAnnouncement
{
    public int Id { get; set; }

    public int? MerchantId { get; set; }

    public int? AnnouncementId { get; set; }

    public int? UserId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
