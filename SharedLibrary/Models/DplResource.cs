using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class DplResource
{
    public int Id { get; set; }

    /// <summary>
    /// id of direct_payment_link table
    /// </summary>
    public int DirectPaymentLinkId { get; set; }

    /// <summary>
    /// Brandresource path for example &quot;merchant/dpl/2252/WHgR9BkJYyACPd62YR0NP3rA2Gizn6g2HU6YUL5W.jpg&quot;
    /// </summary>
    public string FilePath { get; set; } = null!;

    /// <summary>
    /// 0 = inactive, 1 = active
    /// </summary>
    public sbyte? Status { get; set; }

    /// <summary>
    /// 1 = primary/cover photo 
    /// 0 = not primary
    /// </summary>
    public bool? IsPrimary { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public const sbyte STATUS_ACTIVE = 1;
    public const sbyte STATUS_INACTIVE = 2;
}
