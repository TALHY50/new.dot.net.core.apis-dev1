using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class IntegratorPermission
{
    public int Id { get; set; }

    public int IntegratorId { get; set; }

    public string Permissions { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
