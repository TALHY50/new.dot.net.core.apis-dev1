using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class ChatMessage
{
    public ulong Id { get; set; }

    public ulong ChatId { get; set; }

    public ulong SenderId { get; set; }

    public string? Message { get; set; }

    public string? ReadBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? DeletedFor { get; set; }
}
