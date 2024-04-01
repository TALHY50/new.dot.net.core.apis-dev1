using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class ChatUser
{
    public ulong Id { get; set; }

    public ulong ChatId { get; set; }

    public ulong UserId { get; set; }

    /// <summary>
    /// 1=&gt;true, 0=&gt;false
    /// </summary>
    public bool IsMuted { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
