using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class Ticket
{
    public uint Id { get; set; }

    public int? UserId { get; set; }

    public int? TicketcategoryId { get; set; }

    public string? TicketId { get; set; }

    public string? Title { get; set; }

    public string? Priority { get; set; }

    public string? Message { get; set; }

    public string? Attachment { get; set; }

    public string? Status { get; set; }

    /// <summary>
    /// 0=customer, 2=merchant
    /// </summary>
    public sbyte? UserType { get; set; }

    public int? ClosedBy { get; set; }

    public string? CloseNote { get; set; }

    public string Messagefrom { get; set; } = null!;

    /// <summary>
    /// tickets current assigned admin user id
    /// </summary>
    public int? AssignedUserId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Authenticated user id
    /// </summary>
    public int ActionById { get; set; }
}
