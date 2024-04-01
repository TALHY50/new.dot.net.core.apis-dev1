using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class Announcement
{
    public int Id { get; set; }

    public int? AdminId { get; set; }

    public string? AdminName { get; set; }

    /// <summary>
    /// merchant id of receivers submerchant
    /// </summary>
    public int? MerchantId { get; set; }

    /// <summary>
    /// list of receivers id
    /// </summary>
    public string? ReceiversId { get; set; }

    /// <summary>
    /// 0=customer, 2=merchant, 3 = submerchant
    /// </summary>
    public sbyte? Type { get; set; }

    public DateTime? AnnouncementDate { get; set; }

    public DateTime? AnnouncementEnd { get; set; }

    /// <summary>
    /// 1=yes, 0=no
    /// </summary>
    public sbyte? IsEmail { get; set; }

    /// <summary>
    /// 1=yes, 0=no
    /// </summary>
    public sbyte? IsPanel { get; set; }

    public string? EnSubject { get; set; }

    public string? EnBody { get; set; }

    public string? TrSubject { get; set; }

    public string? TrBody { get; set; }

    public string? EmailAttachment { get; set; }

    public string? PanelAttachment { get; set; }

    /// <summary>
    /// 2=active, 1=inactive
    /// </summary>
    public sbyte? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
