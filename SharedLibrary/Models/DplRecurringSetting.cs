using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class DplRecurringSetting
{
    public int Id { get; set; }

    public int DplId { get; set; }

    /// <summary>
    /// Number of time(frequency), amount will be deducted
    /// </summary>
    public sbyte PaymentNumber { get; set; }

    /// <summary>
    /// In how many days/week/month/year it will be executed again
    /// </summary>
    public sbyte PaymentInterval { get; set; }

    /// <summary>
    /// D=&gt;Day, W=&gt;Week, M=Month, Y=Year
    /// </summary>
    public string PaymentCycle { get; set; } = null!;

    public string? RecurringWebhookKey { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
