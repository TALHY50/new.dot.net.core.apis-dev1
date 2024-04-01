using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class OutGoingEmail
{
    public int Id { get; set; }

    /// <summary>
    /// from email address
    /// </summary>
    public string? From { get; set; }

    /// <summary>
    /// to email addresses separated by comma
    /// </summary>
    public string? To { get; set; }

    /// <summary>
    /// cc email address
    /// </summary>
    public string? Cc { get; set; }

    /// <summary>
    /// bcc email address
    /// </summary>
    public string? Bcc { get; set; }

    /// <summary>
    /// email subject
    /// </summary>
    public string? Subject { get; set; }

    /// <summary>
    /// email body
    /// </summary>
    public string? Body { get; set; }

    /// <summary>
    /// email attachment path
    /// </summary>
    public string? Attachment { get; set; }

    /// <summary>
    /// 1=yes, 2=no
    /// </summary>
    public sbyte? Unlink { get; set; }

    /// <summary>
    /// 1=low, 2=medium, 3=high, 4=express
    /// </summary>
    public sbyte? Priority { get; set; }

    /// <summary>
    /// 1=smtp, 2=soap
    /// </summary>
    public sbyte? Type { get; set; }

    /// <summary>
    /// 1=pending, 2=in progress, 3=successfully sent, 4=failed
    /// </summary>
    public sbyte? Status { get; set; }

    /// <summary>
    /// email sending exception
    /// </summary>
    public string? Note { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
