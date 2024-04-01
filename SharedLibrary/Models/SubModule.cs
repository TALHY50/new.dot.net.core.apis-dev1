using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class SubModule
{
    public int Id { get; set; }

    public int ModuleId { get; set; }

    public string Name { get; set; } = null!;

    public string ControllerName { get; set; } = null!;

    public string Icon { get; set; } = null!;

    public int Sequence { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string DefaultMethod { get; set; } = null!;

    public string DisplayName { get; set; } = null!;
}
