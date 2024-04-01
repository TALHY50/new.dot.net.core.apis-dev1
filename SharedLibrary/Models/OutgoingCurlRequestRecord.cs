using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class OutgoingCurlRequestRecord
{
    public int Id { get; set; }

    /// <summary>
    /// 1=withdraw, 2=b2cbank, 3=cashout_file_alert, 4=cashout_each_request
    /// </summary>
    public sbyte Type { get; set; }

    /// <summary>
    /// 1=post, 2=get
    /// </summary>
    public sbyte Method { get; set; }

    /// <summary>
    /// request parameters
    /// </summary>
    public string RequestParams { get; set; } = null!;

    /// <summary>
    /// 1=pending, 2=processed, 3=exception
    /// </summary>
    public sbyte Status { get; set; }

    public string? PaymentId { get; set; }

    public string? ExceptionMsg { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
