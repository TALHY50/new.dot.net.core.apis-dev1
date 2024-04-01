using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class SaleRecurringHistory
{
    public int Id { get; set; }

    public int SaleRecurringId { get; set; }

    public int SaleId { get; set; }

    public int MerchantId { get; set; }

    public int SaleRecurringPaymentScheduleId { get; set; }

    public double Amount { get; set; }

    public DateTime ActionDate { get; set; }

    /// <summary>
    /// 1 =&gt; pass, 0 =&gt; Fail
    /// </summary>
    public sbyte Status { get; set; }

    public sbyte RecurringNumber { get; set; }

    public sbyte? Attempts { get; set; }

    public string? Remarks { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
