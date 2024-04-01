using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class TemporaryTransaction
{
    /// <summary>
    /// Auto incrementing
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Transaction ID
    /// </summary>
    public int SenderTransactionId { get; set; }

    public int? ReceiverTransactionId { get; set; }

    /// <summary>
    /// Receiver email that does not exist on user table
    /// </summary>
    public string? ReceiverEmail { get; set; }

    public string? ReceiverPhone { get; set; }

    /// <summary>
    /// Check if email receiver registered.
    /// </summary>
    public string RegistrationStatus { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
