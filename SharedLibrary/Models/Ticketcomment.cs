using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class Ticketcomment
{
    public uint Id { get; set; }

    public int TicketId { get; set; }

    public int UserId { get; set; }

    public string? Comment { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
