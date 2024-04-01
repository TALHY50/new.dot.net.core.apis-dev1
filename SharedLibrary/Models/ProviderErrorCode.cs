using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class ProviderErrorCode
{
    public int Id { get; set; }

    /// <summary>
    /// Provider constants
    /// </summary>
    public string? Provider { get; set; }

    public string? ErrorCode { get; set; }

    public string? ErrorDescription { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
