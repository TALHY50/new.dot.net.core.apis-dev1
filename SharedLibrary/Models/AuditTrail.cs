using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class AuditTrail
{
    public int Id { get; set; }

    public string? ApiName { get; set; }

    public string? Token { get; set; }

    public string? RequestJson { get; set; }

    public string? ResponseJson { get; set; }

    public string? Ip { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime CreatedAt { get; set; }
}
