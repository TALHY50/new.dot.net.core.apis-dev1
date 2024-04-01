using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class ReasonCategory
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
