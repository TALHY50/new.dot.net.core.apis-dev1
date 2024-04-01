using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class NotificationAutomation
{
    public uint Id { get; set; }

    public int? UserId { get; set; }

    public int? MerchantId { get; set; }

    public string? SenderEmail { get; set; }

    public string? ReceiverEmail { get; set; }

    public string? Bcc { get; set; }

    public string? Cc { get; set; }

    public string? Attachment { get; set; }

    public string? Phone { get; set; }

    /// <summary>
    /// 1=&gt; email, 2=&gt;sms
    /// </summary>
    public sbyte? Type { get; set; }

    public sbyte? Attempts { get; set; }

    public string? Subject { get; set; }

    public string Contents { get; set; } = null!;

    /// <summary>
    /// 0 =&gt; not sent yet, 1 =&gt; sent
    /// </summary>
    public sbyte? Status { get; set; }

    public DateTime? DeleteAt { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
