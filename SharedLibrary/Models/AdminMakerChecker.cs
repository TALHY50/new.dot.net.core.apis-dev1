using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class AdminMakerChecker
{
    public int Id { get; set; }

    public int? CreatedById { get; set; }

    public string? CreatedByName { get; set; }

    public int? UpdatedById { get; set; }

    public string? UpdatedByName { get; set; }

    public string Action { get; set; } = null!;

    public string? InputParams { get; set; }

    public string? GetParams { get; set; }

    public string? FileParams { get; set; }

    public string? Section { get; set; }

    public string? ProcessRoute { get; set; }

    public string ProcessMethod { get; set; } = null!;

    /// <summary>
    /// 0=PENDING, 1=APPROVED, 2=REJECTED
    /// </summary>
    public sbyte Status { get; set; }

    public string? UniqueString { get; set; }

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
