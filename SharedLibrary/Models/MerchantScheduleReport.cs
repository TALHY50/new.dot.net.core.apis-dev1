using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class MerchantScheduleReport
{
    public int Id { get; set; }

    public int? MerchantId { get; set; }

    public int? UserId { get; set; }

    /// <summary>
    /// (1= Commision, 2= account Statement, 3= Admin Commission Zip)
    /// </summary>
    public sbyte? Type { get; set; }

    public int? SettlementId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public DateTime? LastExecutionDate { get; set; }

    public DateTime? NextSettlementDate { get; set; }

    public string? FilePath { get; set; }

    /// <summary>
    /// (0=Pending, 1=Processed)
    /// </summary>
    public sbyte? Status { get; set; }

    public sbyte? CurrencyId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
