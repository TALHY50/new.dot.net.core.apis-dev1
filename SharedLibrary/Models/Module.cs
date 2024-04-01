using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class Module
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Icon { get; set; } = null!;

    public int Sequence { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string DisplayName { get; set; } = null!;
}
