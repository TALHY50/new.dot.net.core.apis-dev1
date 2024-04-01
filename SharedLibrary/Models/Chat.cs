using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class Chat
{
    public ulong Id { get; set; }

    /// <summary>
    /// single or group
    /// </summary>
    public string Type { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? Name { get; set; }
}
