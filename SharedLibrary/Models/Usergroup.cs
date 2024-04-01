using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class Usergroup
{
    public int Id { get; set; }

    public string GroupName { get; set; } = null!;

    public string? DashboardUrl { get; set; }

    public bool Status { get; set; }

    public int CompanyId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
