using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class GovBtransReportHistory
{
    public int Id { get; set; }

    public string? FileName { get; set; }

    /// <summary>
    /// Unique Batch Number
    /// </summary>
    public string? Batch { get; set; }

    /// <summary>
    /// 1=EPKBB
    /// 2=SFP
    /// 3=YT
    /// </summary>
    public sbyte? Type { get; set; }

    public int? Counter { get; set; }

    public string? RemoteStatus { get; set; }

    /// <summary>
    /// 0 =&gt; Not Processed , 1 =&gt; Pending, 2 =&gt; Rejected, 3 =&gt; Completed
    /// </summary>
    public sbyte? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Next Processable Datetime for CronJOB
    /// </summary>
    public DateTime? NextProcessDatetime { get; set; }
}
