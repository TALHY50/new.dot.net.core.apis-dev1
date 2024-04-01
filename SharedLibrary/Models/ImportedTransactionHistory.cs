using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class ImportedTransactionHistory
{
    public int Id { get; set; }

    public string? TerminalId { get; set; }

    public int? MerchantId { get; set; }

    /// <summary>
    /// pending = 0, processing = 2, completed = 1, failed = 3
    /// </summary>
    public sbyte? Status { get; set; }

    /// <summary>
    /// 1 =&gt; Oxivo, 2 =&gt; Pavo
    /// </summary>
    public sbyte? Type { get; set; }

    public DateTime? FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    /// <summary>
    /// Used For Import Transaction API
    /// </summary>
    public string? LastProcessedId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
