using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class UserUsergroup
{
    public int Id { get; set; }

    public int UsergroupId { get; set; }

    public int UserId { get; set; }

    public int CompanyId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
