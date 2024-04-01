using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class SaleRecurringCard
{
    public int Id { get; set; }

    public int SaleRecurringId { get; set; }

    public string CardToken { get; set; } = null!;

    public string? CardUserKey { get; set; }

    /// <summary>
    /// 0=&gt;inactive, 1=active
    /// </summary>
    public sbyte? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
