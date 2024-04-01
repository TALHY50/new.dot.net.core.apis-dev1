using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class ServiceType
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string NameTr { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
