using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class SmsArchive
{
    public int Id { get; set; }

    public string? ToGsm { get; set; }

    public string? Provider { get; set; }

    public int UserId { get; set; }

    /// <summary>
    /// 0=&gt;customer; 1=&gt;admin; 2=&gt;merchant; 3=&gt;submerchant
    /// </summary>
    public sbyte? UserType { get; set; }

    public string? Content { get; set; }

    public string? Response { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
