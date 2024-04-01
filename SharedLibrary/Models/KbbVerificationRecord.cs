using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class KbbVerificationRecord
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Tckn { get; set; } = null!;

    public string Iban { get; set; } = null!;

    /// <summary>
    /// (0=customer, 1=admin, 2=merchant) default 0
    /// </summary>
    public sbyte UserType { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
