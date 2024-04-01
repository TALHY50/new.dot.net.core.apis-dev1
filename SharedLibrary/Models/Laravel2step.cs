using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class Laravel2step
{
    public uint Id { get; set; }

    public uint UserId { get; set; }

    public string? AuthCode { get; set; }

    public int AuthCount { get; set; }

    public bool AuthStatus { get; set; }

    public DateTime? AuthDate { get; set; }

    public DateTime? RequestDate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
