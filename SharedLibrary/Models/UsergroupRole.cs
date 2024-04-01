using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class UsergroupRole
{
    public int Id { get; set; }

    public int UsergroupId { get; set; }

    public int RoleId { get; set; }

    public int CompanyId { get; set; }
}
