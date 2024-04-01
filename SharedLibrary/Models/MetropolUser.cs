using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class MetropolUser
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string CustomerNumber { get; set; } = null!;

    public string AccountToken { get; set; } = null!;

    public string Pan { get; set; } = null!;

    public sbyte Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
