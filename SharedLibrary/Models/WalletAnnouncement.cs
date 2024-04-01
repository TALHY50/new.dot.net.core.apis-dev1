using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class WalletAnnouncement
{
    public int Id { get; set; }

    public int? AdminId { get; set; }

    public string? AdminName { get; set; }

    /// <summary>
    /// 1=not verified, 2=verified, 3=verified plus
    /// </summary>
    public sbyte? UserCategory { get; set; }

    /// <summary>
    /// 0=&gt;customer; 1=&gt;admin; 2=&gt;merchant; 3=&gt;submerchant; 4=&gt;integrator; 5=&gt;sales admin; 6=&gt;sales expert
    /// </summary>
    public sbyte UserType { get; set; }

    /// <summary>
    /// 2=active, 1=inactive
    /// </summary>
    public sbyte? Status { get; set; }

    /// <summary>
    /// 0=no, 1=yes
    /// </summary>
    public sbyte? IsEmail { get; set; }

    /// <summary>
    /// 0=no, 1=yes
    /// </summary>
    public sbyte? IsPanel { get; set; }

    public string? EnSubject { get; set; }

    public string? EnBody { get; set; }

    public string? TrSubject { get; set; }

    public string? TrBody { get; set; }

    public string? EmailAttachment { get; set; }

    public string? PanelAttachment { get; set; }

    public DateTime? AnnouncementDate { get; set; }

    public DateTime? AnnouncementEnd { get; set; }

    public sbyte? Order { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
