using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class ChangePasswordHistory
{
    public uint Id { get; set; }

    public int UserId { get; set; }

    public string Passwords { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
