using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class TestPo
{
    public int Id { get; set; }

    /// <summary>
    /// cron interval
    /// </summary>
    public int PosId { get; set; }

    /// <summary>
    /// currency primary key
    /// </summary>
    public int CurrencyId { get; set; }

    /// <summary>
    /// pos amount
    /// </summary>
    public double Amount { get; set; }

    /// <summary>
    /// next checking time
    /// </summary>
    public DateTime? NextActionDate { get; set; }

    /// <summary>
    /// 0=&gt;inactive, 1=&gt;active
    /// </summary>
    public bool? Status { get; set; }

    /// <summary>
    /// 0 = failed email notification sent ,
    /// 1 = success email notification sent
    /// </summary>
    public bool? EmailSentStatus { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
