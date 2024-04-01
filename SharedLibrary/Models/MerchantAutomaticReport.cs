using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class MerchantAutomaticReport
{
    public int Id { get; set; }

    public int MerchantId { get; set; }

    public int TransactionStateId { get; set; }

    public int PaymentRecOptionId { get; set; }

    public string DatePeriod { get; set; } = null!;

    public string DayName { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
}
