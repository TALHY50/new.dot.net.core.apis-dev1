using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class Notification
{
    public Guid Id { get; set; }

    /// <summary>
    /// Notification Sub Category Table Id to manage notification type
    /// </summary>
    public uint? NotificationSubcategoryId { get; set; }

    public string Type { get; set; } = null!;

    public string NotifiableType { get; set; } = null!;

    public ulong NotifiableId { get; set; }

    public uint UserType { get; set; }

    public string? DataTr { get; set; }

    public string? DataEn { get; set; }

    public DateTime? ReadAt { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
