using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class TicketConversation
{
    public uint Id { get; set; }

    public string? TicketId { get; set; }

    public int? UserId { get; set; }

    public int? TicketcategoryId { get; set; }

    public string? Title { get; set; }

    public string? Priority { get; set; }

    public string? Message { get; set; }

    public string? Attachment { get; set; }

    public int? ClosedBy { get; set; }

    public string Messagefrom { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
