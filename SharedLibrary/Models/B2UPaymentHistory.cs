using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class B2UPaymentHistory
{
    public uint Id { get; set; }

    public string? B2bPaymentId { get; set; }

    public string? SenderName { get; set; }

    public string? SenderPhone { get; set; }

    public string? SenderTckn { get; set; }

    public string? ReceiverName { get; set; }

    public string? ReceiverPhone { get; set; }

    public string? ReceiverTckn { get; set; }

    public string? ReferenceNumber { get; set; }

    public string? ReceiverAddress { get; set; }

    /// <summary>
    /// 1-&gt; completed, 2-&gt; rejected, 3-&gt; pending
    /// </summary>
    public sbyte? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
