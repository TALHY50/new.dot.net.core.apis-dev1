using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class RoleSetting
{
    public int Id { get; set; }

    public int? RoleId { get; set; }

    public sbyte? IsAllowMerchantAuthEmail { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
