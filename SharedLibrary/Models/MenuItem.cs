using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class MenuItem
{
    public uint Id { get; set; }

    public uint? MenuId { get; set; }

    public string Title { get; set; } = null!;

    public string Url { get; set; } = null!;

    public string Target { get; set; } = null!;

    public string? IconClass { get; set; }

    public string? Color { get; set; }

    public int? ParentId { get; set; }

    public int Order { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? Route { get; set; }

    public string? Parameters { get; set; }

    public virtual Menu? Menu { get; set; }
}
