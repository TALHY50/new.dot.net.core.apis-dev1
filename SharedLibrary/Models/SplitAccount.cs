using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class SplitAccount
{
    public int Id { get; set; }

    public int SenderId { get; set; }

    public string? PaymentId { get; set; }

    public double SenderAmount { get; set; }

    public double TotalAmount { get; set; }

    public int NumberOfMember { get; set; }

    /// <summary>
    /// 0 = no one paid, 1 = some paid, 2 = all paid, 3 = expired
    /// </summary>
    public sbyte Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
