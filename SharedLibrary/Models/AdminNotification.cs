using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class AdminNotification
{
    public uint Id { get; set; }

    public uint NotificationSubcategoryId { get; set; }

    public uint UsergroupId { get; set; }

    public uint UserId { get; set; }

    public string DataEn { get; set; } = null!;

    public string DataTr { get; set; } = null!;

    public sbyte IsSms { get; set; }

    public sbyte IsEmail { get; set; }

    public sbyte IsPush { get; set; }

    /// <summary>
    /// &apos;0 =&gt; Not Read, 1 =&gt; Readed&apos;
    /// </summary>
    public sbyte IsRead { get; set; }

    public DateTime? ReadAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
