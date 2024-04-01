using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class RolePageHistory
{
    public int Id { get; set; }

    /// <summary>
    /// role_id for role table ID
    /// </summary>
    public int RoleId { get; set; }

    /// <summary>
    /// page_id for page table ID
    /// </summary>
    public int PageId { get; set; }

    /// <summary>
    /// 1= Active, 2 = InActive
    /// </summary>
    public bool Status { get; set; }

    /// <summary>
    /// creator auth user id
    /// </summary>
    public int? AllowedById { get; set; }

    /// <summary>
    /// updated auth user ID
    /// </summary>
    public int? DisallowedById { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
