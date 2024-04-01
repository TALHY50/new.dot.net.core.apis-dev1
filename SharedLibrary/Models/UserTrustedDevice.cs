using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class UserTrustedDevice
{
    public int Id { get; set; }

    /// <summary>
    /// user id or merchant auth user id
    /// </summary>
    public int? UserId { get; set; }

    /// <summary>
    /// mac id of trusted device
    /// </summary>
    public string? DeviceId { get; set; }

    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// expiration of being treated as trusted device
    /// </summary>
    public DateTime? ExpiredAt { get; set; }
}
