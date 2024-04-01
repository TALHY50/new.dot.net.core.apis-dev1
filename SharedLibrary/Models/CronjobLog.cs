using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class CronjobLog
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string PanelName { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string LogData { get; set; } = null!;
}
