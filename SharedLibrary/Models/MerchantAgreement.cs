using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class MerchantAgreement
{
    public int Id { get; set; }

    public string? EnSubject { get; set; }

    public string? EnBody { get; set; }

    public string? TrSubject { get; set; }

    public string? TrBody { get; set; }

    /// <summary>
    /// 1=active, 0=inactive
    /// </summary>
    public sbyte? Status { get; set; }

    public int? CreatedByUserId { get; set; }

    public int? UpdatedByUserId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
