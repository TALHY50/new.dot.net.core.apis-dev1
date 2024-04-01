using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class MerchantReportHistory
{
    public int Id { get; set; }

    public int? MerchantId { get; set; }

    public int? UserId { get; set; }

    /// <summary>
    /// (1=merchant: report transaction, 2=admin: account statement, 3=admin: all transaction, 4=merchant: all transaction, 5=merchant:  account statement, 6=admin: chargeBack, 7=Merchant: ChargeBack, 8=admin: Refunded, 9=merchant: Refunded, 10=Bank settlement Report) default 0
    /// </summary>
    public sbyte? ReportType { get; set; }

    /// <summary>
    /// (1=CSV, 2=XLS, 3=PDF) default 0
    /// </summary>
    public sbyte? Format { get; set; }

    /// <summary>
    /// (0=Pending, 1=Processed, 2=Expired, 3=Awaiting, 9= Awaiting Big Data) default 0
    /// </summary>
    public sbyte? Status { get; set; }

    public string? Params { get; set; }

    public DateTime? RequestAt { get; set; }

    public int? DownloadCount { get; set; }

    public string? FileUrl { get; set; }

    /// <summary>
    /// 0=request by human, 1= request by automation system
    /// </summary>
    public sbyte? Source { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
