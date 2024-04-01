using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class SaleRecurring
{
    public int Id { get; set; }

    public string PlanCode { get; set; } = null!;

    public string? RecurringWebHookKey { get; set; }

    public double FirstAmount { get; set; }

    public double RecurringAmount { get; set; }

    public double TotalAmount { get; set; }

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

    public string FirstOrderId { get; set; } = null!;

    public int BankId { get; set; }

    public int CurrencyId { get; set; }

    public int MerchantId { get; set; }

    public string CardNo { get; set; } = null!;

    public string? CardUserKey { get; set; }

    public DateTime NextActionDate { get; set; }

    public sbyte? Count { get; set; }

    public sbyte MigrationStatus { get; set; }

    /// <summary>
    /// 1=active, 0=inactive
    /// </summary>
    public sbyte? Status { get; set; }

    public string? Comment { get; set; }

    /// <summary>
    /// 1 = inactive by failed payment number exceed by cronjobb
    /// 2 = completed all recurring by cronjob 
    /// 3 = inactivated by admin
    /// 4 = inactivated by merchant
    /// 5 = inactivated by API
    /// 0 = not set
    /// </summary>
    public sbyte Type { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Authenticated user id
    /// </summary>
    public int ActionById { get; set; }
}
