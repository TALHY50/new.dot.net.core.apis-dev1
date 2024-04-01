using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class Role
{
    public int Id { get; set; }

    /// <summary>
    /// creator auth ID
    /// </summary>
    public int? CreatedById { get; set; }

    /// <summary>
    /// approve auth ID
    /// </summary>
    public int? UpdatedById { get; set; }

    public string? Title { get; set; }

    public string? Name { get; set; }

    public bool Status { get; set; }

    public int CompanyId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
