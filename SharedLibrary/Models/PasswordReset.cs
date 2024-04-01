using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class PasswordReset
{
    public uint Id { get; set; }

    public string Email { get; set; } = null!;

    /// <summary>
    /// 0=customer, 1=admin, 2=merchant, 3=submerchant, 4=integrator
    /// </summary>
    public sbyte? UserType { get; set; }

    public string Token { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }
}
