using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class SaleRecurringPaymentSchedule
{
    public int Id { get; set; }

    public int SaleRecurringId { get; set; }

    public int RecurringNumber { get; set; }

    public DateOnly ActionDate { get; set; }

    /// <summary>
    /// 0=not processed yet, 1= already processed
    /// </summary>
    public sbyte Status { get; set; }

    /// <summary>
    /// for failed attempt count
    /// </summary>
    public sbyte NumberOfFailedCount { get; set; }

    public double Amount { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime LastAttemptDate { get; set; }

    public string? Comment { get; set; }
}
